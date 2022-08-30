using BookingProject.Business.Abstract;
using BookingProject.Entities.Models;
using ChatApp.Common.Result;
using Microsoft.AspNetCore.Mvc;

namespace BookingProject.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : Controller
    {
        ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpPost]
        [Route("/companies")]
        public async Task<ActionResult> Create([FromBody] Company company)
        {
            try
            {
                return Ok(_companyService.Add(company));
            }
            catch (Exception)
            {

                return BadRequest();

            }
        }



        [HttpPut]
        [Route("/companies")]
        public async Task<ActionResult> Update([FromBody] Company company)
        {
            try
            {
                return Ok(await _companyService.Update(company));
            }
            catch (Exception)
            {
                return BadRequest();

            }

        }

          

        

        [HttpDelete]
        [Route("/companies/id")]
        public async Task<ActionResult> Delete([FromBody] int id)
        {

            try
            {
                _companyService.Delete(companyId: id);
                 return Ok();
                
               
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                 "Error deleting data");
            }
          
            
            
          
        }


        [HttpGet]
        [Route("/companies")]
        public async Task<ActionResult> GetAll()
        {

            return Ok(await _companyService.GetAll());
        }



        [HttpGet]
        [Route("/companies/id")]
        public async Task<ActionResult> GetById(int id)
        {

            return Ok(await _companyService.GetById(companyId: id));
        }
        










    }
}

