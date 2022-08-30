using BookingProject.Business.Abstract;
using BookingProject.Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Protocol;
using System.Net;

namespace BookingProject.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : Controller
    {
        IBookingService _bookingService;
        public BookingController(IBookingService bookingService)
        {
            _bookingService=bookingService; 
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
        [Route("/bookings/search")]
        public async Task<ActionResult> SearchBooking(string? firstName = null, string? lastName = null, string? startDate = null, string? finishDate = null, string? appartmentName = null, int? confirmed = null)
        {
            try
            {
                return Ok( _bookingService.SearchForBooking(firstName: firstName, lastName: lastName, startDate: startDate, finishDate: finishDate, appartmentName: appartmentName, confirmed: confirmed));
            }
            catch (Exception)
            {

                return BadRequest();
            }
          
        }



        [HttpPost]
        [Route("/bookings")]
        public async Task<ActionResult> Create([FromBody] Booking booking)
        {
      
            try
            {
                return  Ok(await _bookingService.Add(booking));
            }
            catch (Exception)
            {

            return BadRequest();
            }
          



        }
        [HttpPut]
        [Route("/bookings")]
        public async Task<ActionResult> Update([FromBody] Booking booking)
        {
           
            try
            {
                return Ok(await _bookingService.Update(booking));
            }

            catch (Exception ex)
            {
                return BadRequest();
            }


        }

        [HttpDelete]
        [Route("/bookings/id")]
        public async Task<ActionResult> Delete([FromBody] int id)
        {

            
           try
            {
              
                      return Ok( _bookingService.Delete(bookingId: id));
              
            }
            catch(Exception) {
                return StatusCode(StatusCodes.Status500InternalServerError,
             "Error deleting data");
            }
        }


        [HttpGet]
        [Route("/bookings")]
        public async Task<ActionResult> GetAll()
        {

            return Ok(await _bookingService.GetAll());
        }



        [HttpGet]
        [Route("/bookings/id")]
        public async Task<ActionResult> GetById(int id)
        {

            return Ok(await _bookingService.GetById(bookingId: id));
        }


        



    }
}
