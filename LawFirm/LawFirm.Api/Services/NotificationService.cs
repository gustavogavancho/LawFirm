using LawFirm.Application.Features.Events.Commands.UpdateEventNotification;
using LawFirm.Application.Features.Events.Queries.GetEventsByDate;
using LawFirm.Infrastructure.Notification;
using MediatR;
using Microsoft.AspNetCore.SignalR;

namespace LawFirm.Api.Services;

public class NotificationService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;

    public NotificationService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);

            using (var scope = _serviceProvider.CreateScope())
            {
                var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                var hubContext = scope.ServiceProvider.GetRequiredService<IHubContext<NotificationHub>>();

                var utcNow = DateTime.UtcNow;

                var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");

                var gmtMinus5Time = TimeZoneInfo.ConvertTimeFromUtc(utcNow, timeZoneInfo);

                var minTime = gmtMinus5Time.AddMinutes(15);

                var events = await mediator.Send(new GetEventsByDateQuery { CurrentDate = gmtMinus5Time });

                var upcomingEvents = events.Where(e => e.EventStartDate >= gmtMinus5Time && e.EventStartDate <= minTime);

                foreach (var @event in upcomingEvents)
                {
                    await hubContext.Clients.All.SendAsync("ReceiveMessage", $"Event {@event.Title} is starting in about fifteen minutes.");

                    await mediator.Send(new UpdateEventNotificationCommand { Id = @event.Id });
                }
            }
        }
    }
}
