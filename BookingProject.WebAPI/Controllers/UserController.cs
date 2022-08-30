using BookingProject.Business.Abstract;
using BookingProject.Business.Concrete;
using BookingProject.Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ChatApp.Common.Result;

namespace BookingProject.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("/users")]
        public async Task<ActionResult> Create([FromBody] User user)
        {
            try
            {
             return Ok(await _userService.Add(user));
            }
            catch (Exception)
            {

                return BadRequest();
            }

           
            
            
           


        }
        [HttpPut]
        [Route("/users")]
        public async Task<ActionResult>  Update([FromBody] User user)
        {
            try
            {
             return Ok(await _userService.Update(user));
            }
            catch (Exception)
            {

                return BadRequest();
            }
           

           
          

           


        }

        [HttpDelete]
        [Route("/users/id")]
        public async Task<ActionResult> Delete([FromBody]int id)
        {



            try
            {
                _userService.Delete(userId: id);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }


           
                
            
            
            
          
            
           
        }


        [HttpGet]
        [Route("/users")]
        public async Task<ActionResult> GetAll()
         {
            try
            {
                return Ok(await _userService.GetAll());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,"Error retrieving data from database");

            }
          
         }



        [HttpGet]
        [Route("/users/id")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                return Ok(await _userService.GetById(userId:id));
            }
            catch (Exception)
            {
                return BadRequest(); ;

            }
        }







    }
}
