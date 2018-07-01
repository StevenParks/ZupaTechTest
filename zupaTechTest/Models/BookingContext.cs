using Microsoft.EntityFrameworkCore;

namespace zupaTechTest.Models
{
    public class BookingContext : DbContext
    {
        public BookingContext(DbContextOptions<BookingContext> options)
            : base(options)
        {
        }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Seat> Seats { get; set; }
    }
}