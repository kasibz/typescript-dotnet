using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Todov2.Data;
using Todov2.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Todov2.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // instantiating DataContext to interact with Db
        private readonly DataContext _dbContext;

        // using DI, inject the context to the controller through a constructor
        // allows mocking of a db, decouples db from backend
        public UserController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/user
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            try
            {
                if (_dbContext.User == null)
                {
                    return NotFound();
                }
                return await _dbContext.User.ToListAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        // GET api/user/{id}
        // looks like IActionResult is more for generic types and 
        // ActionResult is more for a specified return like an Entity
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            try
            {
                var user = await _dbContext.User.FirstOrDefaultAsync(x => x.Id == id);
                if (user == null)
                {
                    return NotFound();
                }

                return user;
            } 
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }

        }

        // POST api/user
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
