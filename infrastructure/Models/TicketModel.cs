using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infrastructure.Models
{
    public class TicketModel
    {
        public int Id { get; set; }
        public Guid TicketNumber { get; set; }
        public DateTime PurchasedUTC { get; set; }
        public int UserId { get; set; }
        public int EventId { get; set; }
        public bool CheckedIn { get; set; }
    }
}
