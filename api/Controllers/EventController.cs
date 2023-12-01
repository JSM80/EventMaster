using infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using api.Filters;
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
    [ValidateModel]
    [Route("/api/event")]
    public ResponseDto Post([FromBody]CreateEventRequestDto dto)
    {
        HttpContext.Response.StatusCode = StatusCodes.Status201Created;
        return new ResponseDto()
        {
            MessageToClient = "Successfully created a event",
            ResponseData = _eventService.CreateEvent(dto.Title, dto.Description, dto.OwnerId, dto.EventStatus, 
                dto.eventCardImgUrl, dto.MaximumTickets, dto.Address1, dto.Address2, dto.Zip, dto.City, dto.Country, 
                dto.CreatedAtUTC, dto.StartUTC, dto.EndUTC)
        };
    }
    
    [HttpPut]
    [ValidateModel]
    [Route("/api/event/{eventId}")]
    public ResponseDto Put([FromRoute]int eventId, [FromBody] UpdateEventRequestDto dto)
    {
        HttpContext.Response.StatusCode = 201;
        return new ResponseDto()
        {
            MessageToClient = "Successfully Update a event",
            ResponseData = _eventService.UpdateEvent(dto.Id, dto.Title, dto.Description, dto.OwnerId, dto.EventStatus, 
                dto.eventCardImgUrl, dto.MaximumTickets, dto.Address1, dto.Address2, dto.Zip, dto.City, dto.Country, 
                dto.CreatedAtUTC, dto.StartUTC, dto.EndUTC)
        };
    }

    [HttpDelete]
    [Route("/api/event/{eventId}")]
    public ResponseDto Delete([FromRoute] int eventId)
    {
        _eventService.DeleteEvent(eventId);
        return new ResponseDto()
        {
            MessageToClient = "Successfully deleted"
        };
    }
}
