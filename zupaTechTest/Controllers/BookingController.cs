using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zupaTechTest.Models;

namespace zupaTechTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly BookingContext _context;

        //Constructor, populate the Seats table if it does not have any data
        public BookingController(BookingContext context)
        {
            _context = context;

            if (_context.Seats.Count() == 0)
            {
                for(int letter = 1; letter <= 10; letter++)
                {
                    for(int i = 1; i <=10; i++)
                    {
                        //Create the Letter for the Seat Row, then the number
                        string seatLabel = Number2String(letter, true);
                        seatLabel += i.ToString();

                        //Populate Seat table
                        _context.Seats.Add(new Seat { Label = seatLabel });
                    }
                }

                _context.SaveChanges();
            }
        }

        //Retrieve all Unbooked Seats
        [HttpGet]
        public ActionResult<List<Seat>> GetAllUnbooked()
        {
            return _context.Seats.ToList().Where(seat => seat.BookingId == 0).ToList();
        }
        
        [HttpPost]
        public IActionResult CreateBookings([FromBody]Booking[] bookings)
        {
            if (bookings.Count() > 4)
                return null;

            foreach(Booking booking in bookings)
            {
                //Retrieve the seat from the context, if it is not already booked, book it
                Seat existingSeat = _context.Seats.First(seat => seat.Label == booking.Seat);

                if(existingSeat.BookingId == 0)
                {
                    //Tried adding a Unique Constraint on the table to prevent duplicates on Name and Email, doesn't seem to have worked though
                    //So using this to check for existing combinations
                    var existingNameAndEmail =_context.Bookings.Where(existingBooking => existingBooking.Name == booking.Name && existingBooking.Email == booking.Email);
                    if (existingNameAndEmail.Count() == 0)
                    {
                        _context.Add(booking);
                        _context.SaveChanges();

                        //Save the new booking id to the Seat
                        int id = booking.ID;
                        existingSeat.BookingId = id;
                        _context.SaveChanges();
                    }
                }
                else
                {
                    //Seat has already been booked
                }
            }
            return CreatedAtRoute("Create Bookings", new { bookings = bookings }, bookings);
        }

        //Taken from https://social.msdn.microsoft.com/Forums/vstudio/en-US/78e75d1a-0795-4bdb-8a62-ae6faa909986/convert-number-to-alphabet?forum=csharpgeneral
        private string Number2String(int number, bool isCaps)
        {
            Char c = (Char)((isCaps ? 65 : 97) + (number - 1));
            return c.ToString();
        }
    }
}