using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResiliaWeb.Helpers;
using ResiliaWeb.Models;

namespace ResiliaWeb.Controllers;

[ApiController]
[Route("[controller]")]
public class NotificationController : ControllerBase
{
    private readonly ILogger<NotificationController> _logger;
    private RepositoryContext _context;

    public NotificationController(ILogger<NotificationController> logger,
                                  RepositoryContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetNotifications()
    {
        var notifications = await _context.Notifications.OrderByDescending(n => n.Date).ToListAsync();

        try
        {
            return Ok(notifications);
        }
        catch (Exception ex)
        {
            _logger.LogError("Error retrieving notifications GetNotifications() - " + ex.Message);
            return StatusCode(500, "Server Error");
        }
    }
}

