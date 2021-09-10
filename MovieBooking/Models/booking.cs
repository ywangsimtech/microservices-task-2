using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieBooking.Models
{
    public class booking
    {
        public long Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Venue { get; set; }
        public int NumberofTickets { get; set; }
        public double Amount { get; set; }
        public string Currencies { get; set; }
    }
}
