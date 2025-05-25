using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MonteringService.Data;
using MonteringService.Models;

namespace MonteringService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MonteringApiController : ControllerBase
    {
        private readonly MonteringDbContext _context;

        public MonteringApiController(MonteringDbContext context)
        {
            _context = context;
        }

        // POST: Create new montering job
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MonteringJob job)
        {
            if (string.IsNullOrWhiteSpace(job.RefNo))
                return BadRequest("RefNo is required.");

            var exists = await _context.MonteringJobs.AnyAsync(j => j.RefNo == job.RefNo);
            if (exists) return Conflict("Job already exists.");

            _context.MonteringJobs.Add(job);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: Remove job by RefNo
        [HttpDelete("{refNo}")]
        public async Task<IActionResult> Delete(string refNo)
        {
            var job = await _context.MonteringJobs.FirstOrDefaultAsync(j => j.RefNo == refNo);
            if (job == null) return NotFound();

            _context.MonteringJobs.Remove(job);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
