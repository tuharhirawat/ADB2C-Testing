//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using MyWebApplicationDemo.Models;
//using Microsoft.AspNetCore.Authorization;


//namespace MyWebApplicationDemo.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class UsersController : ControllerBase
//    {
//        private readonly MyWebAppDbContext _context;

//        public UsersController(MyWebAppDbContext context)
//        {
//            _context = context;
//        }

//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
//        {
//            return await _context.Users.ToListAsync();
//        }

//        [Authorize]
//        [HttpGet("{id}")]
//        public async Task<ActionResult<User>> GetUser(int id)
//        {
//            var user = await _context.Users.FindAsync(id);

//            if (user == null)
//            {
//                return NotFound();
//            }

//            return user;
//        }



//        [HttpGet("GetByEmail")]
//        public async Task<ActionResult<User>> GetUserByEmail([FromQuery] string email)
//        {
//            if (string.IsNullOrEmpty(email))
//            {
//                return BadRequest("Email is required.");
//            }

//            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

//            if (user == null)
//            {
//                return NotFound("User not found.");
//            }

//            return Ok(user);
//        }


//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutUser(int id, User user)
//        {
//            if (id != user.Id)
//            {
//                return BadRequest();
//            }

//            _context.Entry(user).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!UserExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return NoContent();
//        }


//        [HttpPost]
//        public async Task<ActionResult<User>> PostUser(User user)
//        {
//            _context.Users.Add(user);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction("GetUser", new { id = user.Id }, user);
//        }



//        [HttpPost("signup")]
//        public async Task<IActionResult> Signup([FromBody] User user)
//        {
//            if (user == null || string.IsNullOrEmpty(user.PasswordHash))
//            {
//                return BadRequest(new { message = "Invalid user data" });
//            }

//            // Hash the password before saving it
//            user.PasswordHash = PasswordHasher.HashPassword(user.PasswordHash);

//            _context.Users.Add(user);
//            await _context.SaveChangesAsync();

//            return Ok(new { message = "User registered successfully!" });
//        }




//        [HttpPost("login")]
//        public async Task<IActionResult> Login([FromBody] LoginRequest loginModel)
//        {
//            if (string.IsNullOrEmpty(loginModel.Email) || string.IsNullOrEmpty(loginModel.PasswordHash))
//            {
//                return BadRequest(new { message = "Email and password are required." });
//            }

//            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == loginModel.Email);

//            if (user == null || !PasswordHasher.VerifyPassword(loginModel.PasswordHash, user.PasswordHash))
//            {
//                return Unauthorized(new { message = "Invalid email or password" });
//            }

//            return Ok(new { message = "Login successful!" });
//        }




//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteUser(int id)
//        {
//            var user = await _context.Users.FindAsync(id);
//            if (user == null)
//            {
//                return NotFound();
//            }

//            _context.Users.Remove(user);
//            await _context.SaveChangesAsync();

//            return NoContent();
//        }

//        private bool UserExists(int id)
//        {
//            return _context.Users.Any(e => e.Id == id);
//        }
//    }
//}



























//// update #1 on  2/12/2024
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.IdentityModel.Tokens;
//using MyWebApplicationDemo.Models;

//namespace MyWebApplicationDemo.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class UsersController : ControllerBase
//    {
//        private readonly MyWebAppDbContext _context;
//        private readonly IConfiguration _configuration;

//        public UsersController(MyWebAppDbContext context, IConfiguration configuration)
//        {
//            _context = context;
//            _configuration = configuration;
//        }

//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
//        {
//            return await _context.Users.ToListAsync();
//        }

//        [Authorize]
//        [HttpGet("{id}")]
//        public async Task<ActionResult<User>> GetUser(int id)
//        {
//            var user = await _context.Users.FindAsync(id);
//            if (user == null)
//            {
//                return NotFound();
//            }
//            return user;
//        }

//        [HttpGet("GetByEmail")]
//        public async Task<ActionResult<User>> GetUserByEmail([FromQuery] string email)
//        {
//            if (string.IsNullOrEmpty(email))
//            {
//                return BadRequest("Email is required.");
//            }

//            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
//            if (user == null)
//            {
//                return NotFound("User not found.");
//            }

//            return Ok(user);
//        }

//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutUser(int id, User user)
//        {
//            if (id != user.Id)
//            {
//                return BadRequest();
//            }

//            _context.Entry(user).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!UserExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return NoContent();
//        }

//        [HttpPost]
//        public async Task<ActionResult<User>> PostUser(User user)
//        {
//            _context.Users.Add(user);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction("GetUser", new { id = user.Id }, user);
//        }

//        [HttpPost("signup")]
//        public async Task<IActionResult> Signup([FromBody] User user)
//        {
//            if (user == null || string.IsNullOrEmpty(user.PasswordHash))
//            {
//                return BadRequest(new { message = "Invalid user data" });
//            }

//            // Hash the password before saving it
//            user.PasswordHash = PasswordHasher.HashPassword(user.PasswordHash);

//            _context.Users.Add(user);
//            await _context.SaveChangesAsync();

//            return Ok(new { message = "User registered successfully!" });
//        }

//        [HttpPost("login")]
//        public async Task<IActionResult> Login([FromBody] LoginRequest loginModel)
//        {
//            if (string.IsNullOrEmpty(loginModel.Email) || string.IsNullOrEmpty(loginModel.PasswordHash))
//            {
//                return BadRequest(new { message = "Email and password are required." });
//            }

//            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == loginModel.Email);
//            if (user == null || !PasswordHasher.VerifyPassword(loginModel.PasswordHash, user.PasswordHash))
//            {
//                return Unauthorized(new { message = "Invalid email or password" });
//            }

//            // Generate JWT Token
//            var token = GenerateJwtToken(user);

//            return Ok(new
//            {
//                Token = token,
//                Message = "Login successful!"
//            });
//        }

//        private string GenerateJwtToken(User user)
//        {
//            var tokenHandler = new JwtSecurityTokenHandler();
//            var key = Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]);

//            var tokenDescriptor = new SecurityTokenDescriptor
//            {
//                Subject = new ClaimsIdentity(new[]
//                {
//                    new Claim(ClaimTypes.Name, user.Email),
//                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
//                }),
//                Expires = DateTime.UtcNow.AddHours(2),
//                Issuer = _configuration["JwtSettings:Issuer"],
//                Audience = _configuration["JwtSettings:Audience"],
//                SigningCredentials = new SigningCredentials(
//                    new SymmetricSecurityKey(key),
//                    SecurityAlgorithms.HmacSha256Signature
//                )
//            };

//            var token = tokenHandler.CreateToken(tokenDescriptor);
//            return tokenHandler.WriteToken(token);
//        }

//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteUser(int id)
//        {
//            var user = await _context.Users.FindAsync(id);
//            if (user == null)
//            {
//                return NotFound();
//            }

//            _context.Users.Remove(user);
//            await _context.SaveChangesAsync();

//            return NoContent();
//        }

//        private bool UserExists(int id)
//        {
//            return _context.Users.Any(e => e.Id == id);
//        }
//    }
//}













// update #2 on  2/12/2024
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebApplicationDemo.Models;
using System.Security.Claims;

namespace MyWebApplicationDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly MyWebAppDbContext _context;

        public UsersController(MyWebAppDbContext context)
        {
            _context = context;
        }

        [Authorize]  // Requires authentication from Azure AD B2C
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        [Authorize]
        [HttpGet("me")]
        public async Task<ActionResult<User>> GetCurrentUser()
        {
            var email = User.FindFirst(ClaimTypes.Name)?.Value;
            if (string.IsNullOrEmpty(email))
            {
                return Unauthorized(new { message = "User not authenticated" });
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
            {
                return NotFound(new { message = "User not found" });
            }

            return Ok(user);
        }

        [Authorize]
        [HttpPut("update")]
        public async Task<IActionResult> UpdateUser([FromBody] User updatedUser)
        {
            var email = User.FindFirst(ClaimTypes.Name)?.Value;
            if (string.IsNullOrEmpty(email))
            {
                return Unauthorized(new { message = "User not authenticated" });
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
            {
                return NotFound(new { message = "User not found" });
            }

            user.FullName = updatedUser.FullName;

            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(new { message = "User updated successfully" });
        }

        [Authorize]
        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteCurrentUser()
        {
            var email = User.FindFirst(ClaimTypes.Name)?.Value;
            if (string.IsNullOrEmpty(email))
            {
                return Unauthorized(new { message = "User not authenticated" });
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
            {
                return NotFound(new { message = "User not found" });
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return Ok(new { message = "User deleted successfully" });
        }
    }
}
