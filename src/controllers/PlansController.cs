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
    public class PlansController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PlansController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "scheme1")]
        public async Task<IActionResult> ListPlans()
        {
            List<Plan> plans = await _context.Plans.Where(p => p.IsActive).ToListAsync();

            return Ok(plans);
        }
    }
}
