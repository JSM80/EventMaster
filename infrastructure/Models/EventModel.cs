using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infrastructure.Models
{
    public class EventModel
    {
        public int Id { get; set; }
        public string Title { get; set; } 
        public string Description { get; set; }
        public int OwnerId { get; set; }
        public bool EventStatus { get; set; }
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
        
        
        public int Sold { get; set; } // Calculated field
        public int Available { get; set; } // Calculated field
    }
}
