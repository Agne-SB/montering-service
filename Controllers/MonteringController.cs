using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MonteringService.Data;
using MonteringService.Models;

namespace MonteringService.Controllers
{
    public class MonteringController : Controller
    {
        private readonly MonteringDbContext _context;

        public MonteringController(MonteringDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var jobs = await _context.MonteringJobs
                .Where(j => j.Status != "Utført" && j.Status != "Retur")
                .ToListAsync();

            return View(jobs);
        }

        [HttpPost]
        public async Task<IActionResult> SetDato(int id, DateTime dato)
        {
            var job = await _context.MonteringJobs.FindAsync(id);
            if (job == null) return NotFound();

            job.MonteringDato = dato;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> SetWorker(int id, string worker)
        {
            var job = await _context.MonteringJobs.FindAsync(id);
            if (job == null) return NotFound();

            job.Worker = worker;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> SetStatus(int id, string status)
        {
            var job = await _context.MonteringJobs.FindAsync(id);
            if (job == null) return NotFound();

            job.Status = status;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
