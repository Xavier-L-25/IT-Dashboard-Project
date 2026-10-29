using IT_Dashboard_API.Data;
using IT_Dashboard_API.DTOs;
using IT_Dashboard_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IT_Dashboard_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
        {
            var users = await _context.UserModel
                .Select(u => new UserDTO(u.FirstName, u.LastName, u.Email, u.Role))
                .ToListAsync();

            return Ok(users);
        }

        // GET: api/users/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<UserDTO>> GetUser(int id)
        {
            var user = await _context.UserModel.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(new UserDTO(user.FirstName, user.LastName, user.Email, user.Role));
        }

        // POST: api/users
        [HttpPost]
        public async Task<ActionResult<UserDTO>> CreateUser([FromBody] UserDTO dto)
        {
            var user = new UserModel
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Role = dto.Role,
                CreatedAt = DateTime.UtcNow
            };

            _context.UserModel.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, dto);
        }

        // PUT: api/users/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserDTO dto)
        {
            var user = await _context.UserModel.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            user.FirstName = dto.FirstName;
            user.LastName = dto.LastName;
            user.Email = dto.Email;
            user.Role = dto.Role;
            user.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/users/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.UserModel.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.UserModel.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}