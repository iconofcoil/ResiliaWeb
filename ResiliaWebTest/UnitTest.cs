using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.Extensions.Logging;
using ResiliaWeb.Controllers;
using ResiliaWeb.Helpers;
using ResiliaWeb.Models;

namespace ResiliaWebTest;

public class UnitTest
{
    private ILogger<NotificationController> logger;

    [Fact]
    public async Task Test1()
    {
        var optionsBuilder = new DbContextOptionsBuilder<RepositoryContext>();
        optionsBuilder.UseInMemoryDatabase("ResiliaNewsInMemory");
        var context = new RepositoryContext(optionsBuilder.Options);

        var notif1 = new Notification();
        notif1.Date = new DateTime(2023, 01, 10, 3, 45, 0);
        notif1.Text = "Notification 1";

        var notif2 = new Notification();
        notif2.Date = new DateTime(2023, 01, 10, 3, 50, 0);
        notif2.Text = "Notification 2";

        context.Add(notif1);
        context.Add(notif2);
        context.SaveChanges();

        var notificationsController = new NotificationController(logger, context);
        var actionResult = await notificationsController.GetNotifications() as OkObjectResult;

        Assert.NotNull(actionResult);
        var notifications = (List<Notification>)actionResult.Value;

        Assert.Equal(2, notifications.Count);
    }
}
