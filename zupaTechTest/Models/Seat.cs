using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zupaTechTest.Models
{
    public class Seat
    {
        public int ID { get; set; }
        public string Label { get; set; }
        public decimal Price { get; set; }
        public int BookingId { get; set; }
    }
}
