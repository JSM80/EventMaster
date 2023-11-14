using System.ComponentModel.DataAnnotations;

namespace infrastructure.DataModels;

public class Event
{
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

public class AddressDto
{
    public string Street { get; set; }
    public int Number { get; set; }
    public int AreaCode { get; set; }
}