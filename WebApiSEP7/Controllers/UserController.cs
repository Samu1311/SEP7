using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using WebApiSEP7.Models; // Ensure this is the correct namespace for your models
using WebApiSEP7.Data; // Ensure this is the correct namespace for your DbContext

namespace SEP7.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _context;

        public UserController(IConfiguration configuration, AppDbContext context)
        {
            _context = context;
            _configuration = configuration;
        }

        // Register a new user
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User model)
        {
            if (await _context.Users.AnyAsync(u => u.Email == model.Email))
            {
                return BadRequest(new { Message = "Email already exists." });
            }

            var user = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PasswordHash = HashPassword(model.PasswordHash), // Use the provided password to generate a hash
                DateOfBirth = model.DateOfBirth,
                Gender = model.Gender,
                EmergencyContact = model.EmergencyContact,
                PhoneNumber = model.PhoneNumber // Ensure this field is set
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new { user.UserId, user.Email });
        }

        // Get all users
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // Get user by ID
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound(new { Message = "User not found." });
            }

            return Ok(user);
        }

        // Update user
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] User model)
        {
            if (id != model.UserId)
            {
                return BadRequest(new { Message = "User ID mismatch." });
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound(new { Message = "User not found." });
            }

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;
            if (!string.IsNullOrEmpty(model.PasswordHash))
            {
                user.PasswordHash = HashPassword(model.PasswordHash);
            }
            user.DateOfBirth = model.DateOfBirth;
            user.Gender = model.Gender;
            user.EmergencyContact = model.EmergencyContact;
            user.PhoneNumber = model.PhoneNumber;
            user.Discount = model.Discount;
            user.SubscriptionId = model.SubscriptionId; // This can be null

            await _context.SaveChangesAsync();

            return Ok(new { Message = "User updated successfully", User = user });
        }

        // Delete user
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound(new { Message = "User not found." });
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "User deleted successfully" });
        }

        // GET: api/user/profile/{userId}
        [HttpGet("profile/{userId}")]
        public async Task<IActionResult> GetUserProfile(int userId)
        {
            var user = await _context.Users.FindAsync(userId);

            if (user == null)
            {
                return NotFound(new { Message = "User not found." });
            }

            var userProfile = new UserProfileResponse
            {
                Name = $"{user.FirstName} {user.LastName}",
                Email = user.Email,
                Phone = user.PhoneNumber,
                DateOfBirth = user.DateOfBirth, // Include date of birth
                Gender = user.Gender // Include gender
            };

            return Ok(userProfile);
        }


        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        public class UserProfileResponse
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public DateTime? DateOfBirth { get; set; } // New field for date of birth
            public string Gender { get; set; } // New field for gender
        }

    }
}