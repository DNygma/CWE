using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CWE.Models;

namespace CWE.Controllers
{
    public class NotifierController : Controller
    {
        private readonly CEA_DBContext _context;

        public NotifierController(CEA_DBContext context)
        {
            _context = context;
           // CWE.Services.Scheduling ScheduleShit = new CWE.Services.Scheduling(_context, "richard.a.anderson@gmail.com");
        }

        // GET: Notifier
        public async Task<IActionResult> Index()
        {
            return View(await _context.Notifier.ToListAsync());
        }

        // GET: Notifier/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notifier = await _context.Notifier
                .SingleOrDefaultAsync(m => m.Notifier_ID == id);
            if (notifier == null)
            {
                return NotFound();
            }

            return View(notifier);
        }

        // GET: Notifier/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Notifier/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Notifier_ID,Notifier_NotificationString")] Notifier notifier)
        {
            if (ModelState.IsValid)
            {
                _context.Add(notifier);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(notifier);
        }

        // GET: Notifier/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notifier = await _context.Notifier.SingleOrDefaultAsync(m => m.Notifier_ID == id);
            if (notifier == null)
            {
                return NotFound();
            }
            return View(notifier);
        }

        // POST: Notifier/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Notifier_ID,Notifier_NotificationString")] Notifier notifier)
        {
            if (id != notifier.Notifier_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(notifier);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotifierExists(notifier.Notifier_ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(notifier);
        }

        // GET: Notifier/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notifier = await _context.Notifier
                .SingleOrDefaultAsync(m => m.Notifier_ID == id);
            if (notifier == null)
            {
                return NotFound();
            }

            return View(notifier);
        }

        // POST: Notifier/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var notifier = await _context.Notifier.SingleOrDefaultAsync(m => m.Notifier_ID == id);
            _context.Notifier.Remove(notifier);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NotifierExists(string id)
        {
            return _context.Notifier.Any(e => e.Notifier_ID == id);
        }
    }
}
