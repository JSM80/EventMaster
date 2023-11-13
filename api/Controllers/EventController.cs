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

    [HttpPost]
    [Route("/Api/Event/Create")]
    public IActionResult Create([FromBody] EventModel model)
    {
        return Ok(model);
    }

    [HttpGet]
    [Route("/Api/Event")]
    public IActionResult GetAll()
    {
        return Ok(new EventModel());
    }

    [HttpGet]
    [Route("/Api/Event/{Id}")]
    public IActionResult Get([FromRoute] int Id)
    {
        return Ok(new EventModel {  Id = Id });
    }

    [HttpPut]
    [Route("/Api/Event/{Id}")]
    public IActionResult Update([FromBody] EventModel model)
    {
        return Ok(model);
    }

    [HttpDelete]
    [Route("/Api/Event/{Id}")]
    public IActionResult Delete([FromRoute] int Id)
    {
        return Ok();
    }
}
