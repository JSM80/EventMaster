using infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;

namespace api.Controllers;

[ApiController]
public class EventController : ControllerBase
{
    private readonly ILogger<EventController> _logger;

    public EventController(ILogger<EventController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [Route("/Api/Event/dummy")]
    public IActionResult dummy()
    {
        return Ok(TimeZoneInfo.Local);
    }

    [HttpPost]
    [Route("/Api/Event/dummy")]
    public IActionResult dummy([FromBody] EventModel eventModel)
    {        
        return Ok(eventModel);
    }
}
