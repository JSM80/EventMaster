using System.ComponentModel.DataAnnotations;
using infrastructure.DataModels;

namespace infrastructure.QueryModels;

public class EventFeedQuery
{
    public int eventId { get; set; }
    [MinLength(5)]
    public string eventName { get; set; }
    public string eventOrganiser  { get; set; }
    public string description { get; set; }
    public string eventCardImgUrl { get; set; }
    public TimeOnly time { get; set; }
    public double price { get; set; }
    public int ticketAmount { get; set; }

    // Nested class for address properties
    public AddressDto address { get; set; }

    public DateOnly date { get; set; }
}