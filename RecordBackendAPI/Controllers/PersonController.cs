using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using RecordBackendAPI.Data;

using SharedData;

namespace RecordBackendAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController(ApplicationDbContext _dbContext, ILogger<PersonController> _logger) : ControllerBase
    {
        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        [HttpPost("AddNewUser")]
        public async Task<IActionResult> AddNewUser([FromBody]User user)
        {
            // Add the user to the database (replace with your actual data access code)
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();

            return Ok("User created successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _dbContext.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound("User not found");
            }

            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] User user)
        {
            var existingUser = await _dbContext.Users.FindAsync(id);

            if (existingUser == null)
            {
                return NotFound("User not found");
            }

            // Update the user properties
            existingUser.Name = user.Name;
            existingUser.Email = user.Email;

            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
