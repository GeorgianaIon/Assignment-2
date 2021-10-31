using System;
using System.Threading.Tasks;
using AdultsServer.Data;
using AdultsServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdultsServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<User>> ValidateUser([FromQuery] string username, [FromQuery] string password)
        {
            Console.WriteLine("Here");
            try
            {
                Console.WriteLine(username);
                Console.WriteLine(password);
                var user = await userService.ValidateUser(username, password);
                Console.WriteLine(user.ToString());
                return Ok(user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
                
            }
        }
        
        
    }
}