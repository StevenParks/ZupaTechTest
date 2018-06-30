using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zupaTechTest.Models
{
    public class Booking
    {
        public int ID { get; set; }
        //Name of the individual who made the booking
        public string Name { get; set; }
        //Email of the individual who made the booking
        public string Email { get; set; }
        //Total price of all Seats in the booking (for future implementation)
        public decimal Total { get; set; }
    }
}
