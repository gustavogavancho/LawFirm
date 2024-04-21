﻿using Microsoft.AspNetCore.SignalR;

namespace LawFirm.Infrastructure.Notification;

public class NotificationHub : Hub
{
    public async Task SendMessage(string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", message);
    }
}