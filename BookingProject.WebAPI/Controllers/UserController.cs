using BookingProject.Business.Abstract;
using BookingProject.Business.Concrete;
using BookingProject.Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookingProject.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("/api/users")]
        public IActionResult Create([FromBody] User user)
        {
            var result = _userService.Add(user);
            if (result.Success == true)
            {
                return Ok();
            }
            
            return BadRequest();


        }
        [HttpPut]
        [Route("/api/users")]
        public IActionResult Update([FromBody] User user)
        {
            var result = _userService.Update(user);
            if (result.Success == true)
            {
                return Ok();
            }

            return BadRequest();


        }

        [HttpDelete]
        [Route("/api/users/id")]
        public ActionResult Delete([FromBody]int id)
        {

            var result = _userService.Delete(userId: id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet]
        [Route("/api/users")]
        public IActionResult GetAll()
         {
            
             return Ok(_userService.GetAll());
         }



        [HttpGet]
        [Route("/api/users/id")]
        public IActionResult GetById(int id)
        {

            return Ok(_userService.GetById(userId:id));
        }







    }
}
