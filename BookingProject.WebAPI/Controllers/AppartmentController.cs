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
        public async Task<ActionResult> Create([FromBody] Appartment apparment)
        {
            try
            {
                return Ok(await _appartmentService.Add(apparment));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }



        }
        [HttpPut]
        [Route("/appartments")]
        public async Task<ActionResult> Update([FromBody] Appartment apparment)
        {

            try
            {
                return Ok(await _appartmentService.Update(apparment));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        [HttpDelete]
        [Route("/appartments/id")]
        public async Task<ActionResult> Delete([FromBody] int id)
        {
            try
            {
                await _appartmentService.Delete(appartmentId: id);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
          
          
        }


        [HttpGet]
        [Route("/appartments")]
        public async Task<ActionResult> GetAll()
        {

            return Ok(await _appartmentService.GetAll());
        }



        [HttpGet]
        [Route("/appartments/id")]
        public async Task<ActionResult> GetById(int id)
        {

            return Ok(await _appartmentService.GetById(appartmentId: id));
        }




















    }
}
