using infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using api.TransferModels;
using service;

namespace api.Controllers;

[ApiController]
public class EventController : ControllerBase
{
    private readonly ILogger<EventController> _logger;
    private readonly EventService _eventService;

    public EventController(ILogger<EventController> logger, EventService eventService)
    {
        _logger = logger;
        _eventService = eventService;
    }

    [HttpGet]
    [Route("/api/events")]
    public ResponseDto Get()
    {
        return new ResponseDto()
        {
            MessageToClient = "Successfully fetched",
            ResponseData = _eventService.GetEventForFeed()
        };
    }
    
    [HttpPost]
    [Route("/api/event")]
    public ResponseDto Post([FromBody]CreateEventRequestDto dto)
    {
        return new ResponseDto()
        {
            MessageToClient = "Successfully created a event",
            ResponseData = _eventService.CreateEvent(dto.eventName, dto.eventOrganiser, dto.description, 
                dto.eventCardImgUrl, dto.time, dto.price, dto.ticketAmount, dto.address, dto.date)
        };
    }
    
/*    [HttpPut]
    [Route("/api/event/{eventId}")]
    public ResponseDto Put([FromRoute]int eventId, [FromBody] UpdateEventRequestDto dto)
    {
        return new ResponseDto()
        {
            MessageToClient = "Successfully Update a event",
            ResponseData = _eventService.UpdateEvent(dto.eventId, dto.eventName, dto.eventOrganiser, dto.description, 
                dto.eventCardImgUrl, dto.time, dto.price, dto.ticketAmount, dto.address, dto.date)
        };
    }
    [HttpGet]
    [Route("/Api/Event/dummy")]
    public IActionResult dummy()
    {
        return Ok(TimeZoneInfo.Local);
   }
*/ 
    [HttpPost]
    [Route("/Api/Event/dummy")]
    public IActionResult dummy([FromBody] EventModel eventModel)
    {        
        return Ok(eventModel);
    }
}
