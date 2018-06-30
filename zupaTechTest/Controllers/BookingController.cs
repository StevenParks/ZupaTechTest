using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace zupaTechTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        //Retrieve all Unbooked Seats

        //Attempt to Book all Seat/Name/Email combinations in an array
        //Loop through each Booking object, check that the seat is still available and the Name/EMail combination does not already exist
        //If all the objects pass, save to the DB as Bookings, if one of them does not pass, return an error message 
    }
}