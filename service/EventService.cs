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

    public Event CreateEvent(string eventName, string eventOrganiser, string description, string eventCardImgUrl, TimeOnly time, double price, int ticketAmount, object address, DateOnly date)
    {
        var doesEventExist = _eventRepository.DoesEventWithNameExist(eventName);
        if (!doesEventExist)
        {
            throw new ValidationException("A event already exists with title" + eventName);
        }

        return _eventRepository.CreateEvent(eventName, eventOrganiser, description, eventCardImgUrl, time, price, ticketAmount, address, date);
    }

    public object? UpdateEvent(int dtoEventId, string dtoEventName, string dtoEventOrganiser, string dtoDescription, string dtoEventCardImgUrl, TimeOnly dtoTime, double dtoPrice, int dtoTicketAmount, AddressDto dtoAddress, DateOnly dtoDate)
    {
        throw new NotImplementedException();
    }
}
