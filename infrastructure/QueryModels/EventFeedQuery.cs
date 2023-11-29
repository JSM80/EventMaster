using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using infrastructure.DataModels;

namespace infrastructure.QueryModels;

public class EventFeedQuery
{
    public int Id { get; set; }
    [MinLength(5)]
    public string Title { get; set; } 
    [MaxLength(500)]
    public string Description { get; set; }
    public int OwnerId { get; set; }
    [DefaultValue(false)]
    public bool eventStatus { get; set; }
    public string eventCardImgUrl { get; set; }
    public int MaximumTickets { get; set; }
    public string Address1 { get; set; }
    public string Address2 { get; set; }
    public int Zip { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public DateTime CreatedAtUTC { get; set; }
    public DateTime StartUTC { get; set; }
    public DateTime EndUTC { get; set; }
}