using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Subscription.Data;
using Subscription.Models;
using Subscription.Data;


namespace Subscription.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignupController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SignupController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Signup([FromBody] Signup signup)
        {
            
            var user = new User
                {
                    Fname = signup.Fname,
                    Lname = signup.Lname,
                    Email = signup.Email,
                    Password = signup.Password
                };
            _context.Users.Add(user);
            var result = await _context.SaveChangesAsync();            
            return Ok(new { success = result > 0, message = result > 0 ? "Signup successful" : "Signup failed" });
        }
    }
}
