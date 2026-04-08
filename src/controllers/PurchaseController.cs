using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Subscription.Data;
using Subscription.Models;
using System.Collections.Generic;

namespace Subscription.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PurchaseController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "scheme1")]
        public async Task<IActionResult> Purchase([FromBody] PurchasePlanRequest request)
        {
            if (request.UserId == 0 || request.PlanId == 0)
                return BadRequest("UserId and PlanId are required.");

            User user = await _context.Users.FindAsync(request.UserId);
            Plan plan = await _context.Plans.FindAsync(request.PlanId);

            if (user == null || plan == null)
            {
                return NotFound("User or plan not found.");
            }

            if (!plan.IsActive)
            {
                return BadRequest("Plan is not active.");
            }

            UserPlan userPlan = new UserPlan
            {
                User = user,
                Plan = plan,
                Status = "Active",
                Expiry = DateTime.UtcNow.AddDays(plan.PaymentFrequencyInDays)
            };
            _context.UserPlans.Add(userPlan);  
            await _context.SaveChangesAsync();         
            return Ok();
        }
    }
}
