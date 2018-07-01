namespace zupaTechTest.Models
{
    public class Seat
    {
        public int ID { get; set; }

        //Seat Label
        public string Label { get; set; }

        //Price, for future implementation, defaults to 0
        public decimal Price { get; set; }

        //Id of associated Booking, defaults to 0
        public int BookingId { get; set; }
    }
}