namespace zupaTechTest.Models
{
    public class Booking
    {
        public int ID { get; set; }

        //The seat to be booked
        public string Seat { get; set; }

        //Name of the individual who the seat is booked for
        public string Name { get; set; }

        //Email of the individual who the seat is booked for
        public string Email { get; set; }
    }
}