using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Subscription.Helpers;
using Subscription.Data;
using Subscription.Models;

namespace Subscription.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public LoginController(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<ActionResult> Login(Login loginModel)
        {
            var message = "User not found";
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == loginModel.Email);
            // if (user == null || !Password.VerifyPassword(loginModel.Password, user.Password))
            // {
            //     return Unauthorized(message);
            // }

            var token = new JwtGen(_configuration);
            return Ok(new { message = "Login successful", token = token.GenerateJwtToken(user.Email, user.Id) });
        }
    }
}
