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
        public IActionResult Post([FromBody]Booking[] bookings)
        {
            if (bookings.Count() > 4)
                return null;

            foreach(Booking booking in bookings)
            { 
                _context.Add(booking);
                _context.SaveChanges();
            }
            return CreatedAtRoute("Create Bookings", new { bookings = bookings }, bookings);
        }

        //Attempt to Book all Seat/Name/Email combinations in an array
        //Loop through each Booking object, check that the seat is still available and the Name/EMail combination does not already exist
        //If all the objects pass, save to the DB as Bookings, if one of them does not pass, return an error message

        //Taken from https://social.msdn.microsoft.com/Forums/vstudio/en-US/78e75d1a-0795-4bdb-8a62-ae6faa909986/convert-number-to-alphabet?forum=csharpgeneral
        private string Number2String(int number, bool isCaps)
        {
            Char c = (Char)((isCaps ? 65 : 97) + (number - 1));
            return c.ToString();
        }
    }
}