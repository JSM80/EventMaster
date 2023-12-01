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

    public Event CreateEvent(string title, string description, int ownerId, bool eventStatus, string eventCardImgUrl,
        int maximumTickets, string address1, string address2, int zip, string city, string country, DateTime createdAtUtc, DateTime startUtc, DateTime endUtc)
    {
        var doesEventExist = _eventRepository.DoesEventWithNameExist(title);
        if (!doesEventExist)
        {
            throw new ValidationException("A event already exists with title" + title);
        }

        return _eventRepository.CreateEvent(title, description, ownerId, eventStatus, eventCardImgUrl, maximumTickets, address1, address2, zip, city, country, createdAtUtc, startUtc, endUtc);
    }

    public Event UpdateEvent(int id, string title, string description, int ownerId, bool eventStatus, string eventCardImgUrl,
        int maximumTickets, string address1, string address2, int zip, string city, string country, DateTime createdAtUtc, DateTime startUtc, DateTime endUtc)
    {
        return _eventRepository.UpdateEvent(id, title, description, ownerId, eventStatus, eventCardImgUrl, maximumTickets, address1, address2, zip, city, country, createdAtUtc, startUtc, endUtc);
    }

    public void DeleteEvent(int eventId)
    {
        var result = _eventRepository.DeleteEvent(eventId);
        if (!result)
        {
            throw new Exception("Could not insert event");
        }
    }
}
