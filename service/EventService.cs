using System.ComponentModel.DataAnnotations;
using infrastructure.DataModels;
using infrastructure.QueryModels;
using infrastructure.Repositories;

namespace service;

public class EventService
{
    private readonly EventRepository _eventRepository;

    public EventService(EventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }

    public IEnumerable<EventFeedQuery> GetEventForFeed()
    {
        return _eventRepository.GetEventForFeed();
    }

    public Event CreateEvent(string Title, string description, int OwnerId, bool eventStatus, string eventCardImgUrl, int MaximumTickets, string Address1, string Address2, int zip, string city, string country, DateTime CreatedAtUTC, DateTime StartUTC, DateTime EndUTC)
    {
        var doesEventExist = _eventRepository.DoesEventWithNameExist(Title);
        if (!doesEventExist)
        {
            throw new ValidationException("A event already exists with title" + Title);
        }

        return _eventRepository.CreateEvent(Title, description, OwnerId, eventStatus, eventCardImgUrl, MaximumTickets, Address1, Address2, zip, city, country, CreatedAtUTC, StartUTC, EndUTC);
    }

    public object? UpdateEvent(string Title, string description, int OwnerId, bool eventStatus, string eventCardImgUrl, int MaximumTickets, string Address1, string Address2, int zip, string city, string country, DateTime CreatedAtUTC, DateTime StartUTC, DateTime EndUTC)
    {
        throw new NotImplementedException();
    }
}
