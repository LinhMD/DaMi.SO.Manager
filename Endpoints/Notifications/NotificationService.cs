using System.Security.Claims;
using CrudApiTemplate.Repository;
using DaMi.SO.Manager.Data.Models;
using DaMi.SO.Manager.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace DaMi.SO.Manager.Endpoints.Notifications;

public class NotificationService(IUnitOfWork work, IHubContext<NotificationHub> notificationHub, IHttpContextAccessor context)
{
    public async Task Notify(OrderMaster orderMaster, string message, string type = "info")
    {
        IEnumerable<string> notifyUserIds = [(orderMaster.SalesManId ?? ""), (orderMaster.ExecutorId ?? ""), "U001"];
        IEnumerable<Notification> notifications = notifyUserIds.Select(n => new Notification
        {
            CreatedDate = DateTime.Now,
            HasSeen = false,
            Message = message,
            RedirectLink = $"/OrderMaster/{orderMaster.RowUniqueId}",
            MessageType = type,
            TargetEmployeeId = n,
            CreatedUserId = context.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier) ?? ""
        });
        foreach (var notification in notifications)
        {
            await work.Get<Notification>().AddAsync(notification);
            await notificationHub.Clients.User(notification.TargetEmployeeId).SendAsync("notify", notification);
        }
    }
}