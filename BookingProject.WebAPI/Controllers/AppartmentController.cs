using BookingProject.Business.Abstract;
using BookingProject.Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookingProject.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppartmentController : Controller
    {
        IAppartmentService _appartmentService;
        public AppartmentController(IAppartmentService appartmentService)
        {
            _appartmentService = appartmentService;
        }

        [HttpPost]
        [Route("/appartments")]
        public IActionResult Create([FromBody] Appartment apparment)
        {
            var result = _appartmentService.Add(apparment);
            if (result.Success == true)
            {
                return Ok();
            }

            return BadRequest();


        }
        [HttpPut]
        [Route("/appartments")]
        public IActionResult Update([FromBody] Appartment apparment)
        {
            var result = _appartmentService.Update(apparment);
            if (result.Success == true)
            {
                return Ok();
            }

            return BadRequest();


        }

        [HttpDelete]
        [Route("/appartments/id")]
        public ActionResult Delete([FromBody] int id)
        {

            var result = _appartmentService.Delete(appartmentId: id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet]
        [Route("/appartments")]
        public IActionResult GetAll()
        {

            return Ok(_appartmentService.GetAll());
        }



        [HttpGet]
        [Route("/appartments/id")]
        public IActionResult GetById(int id)
        {

            return Ok(_appartmentService.GetById(appartmentId: id));
        }




















    }
}
