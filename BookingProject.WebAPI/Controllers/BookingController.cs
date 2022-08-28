using BookingProject.Business.Abstract;
using BookingProject.Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Protocol;

namespace BookingProject.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingController : Controller
    {
        IBookingService _bookingService;
        public BookingController(IBookingService bookingService)
        {
            _bookingService=bookingService; 
        }




        [HttpPost]
        [Route("/api/bookings")]
        public IActionResult Create([FromBody] Booking booking)
        {
            var result = _bookingService.Add(booking);
            if (result.Success == true)
            {
                return Ok();
            }

            return BadRequest();


        }
        [HttpPut]
        [Route("/api/bookings")]
        public IActionResult Update([FromBody] Booking booking)
        {
            var result = _bookingService.Update(booking);
            if (result.Success == true)
            {
                return Ok();
            }

            return BadRequest();


        }

        [HttpDelete]
        [Route("/api/bookings/id")]
        public ActionResult Delete([FromBody] int id)
        {

            var result = _bookingService.Delete(bookingId: id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet]
        [Route("/api/bookings")]
        public IActionResult GetAll()
        {

            return Ok(_bookingService.GetAll());
        }



        [HttpGet]
        [Route("/api/bookings/id")]
        public IActionResult GetById(int id)
        {

            return Ok(_bookingService.GetById(bookingId: id));
        }


        /// <summary>
        /// Searchs For Bookings.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET api/Bookings
        ///     {        
        ///    ....,
        ///        "startDate":  "yyyy/mm/dd-hh:mm",
        ///        "finishDate" : "yyyy/mm/dd-hh:mm",
        ///   ...
        ///        
        ///     }
        /// </remarks>
        /// <param name="booking"></param>     
        [HttpGet]
        [Route("/api/bookings/search")]
        public IActionResult SearchBooking(string? firstName = null, string? lastName = null, string? startDate = null, string? finishDate = null, string? appartmentName = null, int? confirmed = null)
        { 
             return Ok(_bookingService.SearchForBooking(userName: firstName, userSurname: lastName, startDate: startDate, finishDate: finishDate, appartmentName: appartmentName, confirmed: confirmed));
        }





    }
}
