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
            ResponseData = _eventService.CreateEvent(dto.Title, dto.Description, dto.OwnerId, dto.eventStatus, 
                dto.eventCardImgUrl, dto.MaximumTickets, dto.Address1, dto.Address2, dto.Zip, dto.City, dto.Country, 
                dto.CreatedAtUTC, dto.StartUTC, dto.EndUTC)
        };
    }
    
    [HttpPut]
    [Route("/api/event/{eventId}")]
    public ResponseDto Put([FromRoute]int eventId, [FromBody] UpdateEventRequestDto dto)
    {
        return new ResponseDto()
        {
            MessageToClient = "Successfully Update a event",
            ResponseData = _eventService.UpdateEvent(dto.Title, dto.Description, dto.OwnerId, dto.EventStatus, 
                dto.eventCardImgUrl, dto.MaximumTickets, dto.Address1, dto.Address2, dto.Zip, dto.City, dto.Country, 
                dto.CreatedAtUTC, dto.StartUTC, dto.EndUTC)
        };
    }
}
