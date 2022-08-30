using BookingProject.Business.Abstract;
using BookingProject.Entities.Models;
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
        public IActionResult Create([FromBody] Company company)
        {
            var result = _companyService.Add(company);
            if (result.Success == true)
            {
                return Ok();
            }

            return BadRequest();


        }
        [HttpPut]
        [Route("/companies")]
        public IActionResult Update([FromBody] Company company)
        {
            var result = _companyService.Update(company);
            if (result.Success == true)
            {
                return Ok();
            }

            return BadRequest();


        }

        [HttpDelete]
        [Route("/companies/id")]
        public ActionResult Delete([FromBody] int id)
        {

            var result = _companyService.Delete(companyId: id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet]
        [Route("/companies")]
        public IActionResult GetAll()
        {

            return Ok(_companyService.GetAll());
        }



        [HttpGet]
        [Route("/companies/id")]
        public IActionResult GetById(int id)
        {

            return Ok(_companyService.GetById(companyId: id));
        }
        










    }
}
