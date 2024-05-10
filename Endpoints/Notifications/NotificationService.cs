using Microsoft.Data.SqlClient;
using System.Security.Claims;
using CrudApiTemplate.Repository;
using CrudApiTemplate.Utilities;
using DaMi.SO.Manager.Data;
using DaMi.SO.Manager.Data.Models;
using DaMi.SO.Manager.Hubs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace DaMi.SO.Manager.Endpoints.Notifications;

public class NotificationService(IUnitOfWork work, IHubContext<NotificationHub> notificationHub, IHttpContextAccessor context, DaMiSoManagerContext dbContext)
{
    public async Task Notify(OrderMaster orderMaster, string message, string type = "info")
    {
        IEnumerable<string> notifyUserIds = [(orderMaster.SalesManId ?? ""), (orderMaster.ExecutorId ?? ""), "U001"];
        IEnumerable<Notification> notifications = notifyUserIds.Select(n => new Notification
        {
            CreatedDate = DateTime.Now,
            HasSeen = false,
            Message = message,
            RedirectLink = $"/OrderMaster/Details/{orderMaster.RowUniqueId}",
            MessageType = type,
            TargetEmployeeId = n,
            CreatedUserId = context.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier) ?? ""
        });
        foreach (var notification in notifications)
        {
            try
            {

                await work.Get<Notification>().AddAsync(notification);
                var FromUserID = new SqlParameter
                {
                    ParameterName = "FromUserID",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Size = 20,
                    Value = notification.CreatedUserId,
                };

                var ToUserID = new SqlParameter
                {
                    ParameterName = "@ToUserID",
                    SqlDbType = System.Data.SqlDbType.VarChar,
                    Size = 20,
                    Value = notification.TargetEmployeeId
                };
                var NotifiMsg = new SqlParameter
                {
                    ParameterName = "@NotifiMsg",
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                    Size = 2000,
                    Value = notification.Message
                };
                var IsHighLevel = new SqlParameter
                {
                    ParameterName = "@IsHighLevel",
                    SqlDbType = System.Data.SqlDbType.Bit,
                    Value = true
                };
                dbContext.Database.ExecuteSqlRaw
                (
                    "EXECUTE [dbo].[spSendSMSInbox] @FromUserID, @ToUserID, @NotifiMsg, @IsHighLevel",
                    FromUserID,
                    ToUserID,
                    NotifiMsg,
                    IsHighLevel
                );
                await notificationHub.Clients.User(notification.TargetEmployeeId).SendAsync("notify", notification);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}