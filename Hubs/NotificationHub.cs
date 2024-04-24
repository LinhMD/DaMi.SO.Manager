using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DaMi.SO.Manager.Data.Models;
using Microsoft.AspNetCore.SignalR;

namespace DaMi.SO.Manager.Hubs;

public class NotificationHub : Hub
{
    public async Task SendMessage(string user, string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }
    public async Task Notify(Notification notification)
    {
        await Clients.User(notification.TargetEmployeeId).SendAsync("notify", notification);
    }
}