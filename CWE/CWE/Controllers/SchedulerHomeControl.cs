using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CWE.Models;
using System.Threading;

namespace CWE.Controllers
{
    public class SchedulerHomeControl : Controller
    {
        private readonly CEA_DBContext _context;
        public void CallSchedulerThread()
        {
            CEA_DBContext context;
            context = _context;
            // Start Scheduling
            CWE.Services.Scheduling Start = new CWE.Services.Scheduling(_context);

            while (true)
            {
                // Sleep scheduler for 10 seconds to give the parser some time to do work
                Thread.Sleep(10000);
                Start.RunScheduler(context);
            }
        }

        public SchedulerHomeControl(CEA_DBContext context)
        {
            _context = context;
            // Put in place to call a seperate thread to allow our requests to be simultaneously
            // running while user is doing other tasks
            ThreadStart scheduleref = new ThreadStart(CallSchedulerThread);
            Thread schedThread = new Thread(scheduleref);
            schedThread.Name = "Currency Scheduler Thread";
            schedThread.Start();
        }

        // GET: SchedulerHomeControl
        public async Task<IActionResult> Index()
        {
            return View(await _context.Scheduler.ToListAsync());
        }

        // GET: SchedulerHomeControl/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scheduler = await _context.Scheduler
                .SingleOrDefaultAsync(m => m.Scheduler_UserID == id);
            if (scheduler == null)
            {
                return NotFound();
            }

            return View(scheduler);
        }

        // GET: SchedulerHomeControl/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SchedulerHomeControl/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Scheduler_UserID,Scheduler_Pair,Scheduler_RequestRate,Scheduler_TargetRate,Scheduler_ActualRate")] Scheduler scheduler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(scheduler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(scheduler);
        }

        // GET: SchedulerHomeControl/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scheduler = await _context.Scheduler.SingleOrDefaultAsync(m => m.Scheduler_UserID == id);
            if (scheduler == null)
            {
                return NotFound();
            }
            return View(scheduler);
        }

        // POST: SchedulerHomeControl/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Scheduler_UserID,Scheduler_Pair,Scheduler_RequestRate,Scheduler_TargetRate,Scheduler_ActualRate")] Scheduler scheduler)
        {
            if (id != scheduler.Scheduler_UserID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(scheduler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SchedulerExists(scheduler.Scheduler_UserID))
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
            return View(scheduler);
        }

        // GET: SchedulerHomeControl/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scheduler = await _context.Scheduler
                .SingleOrDefaultAsync(m => m.Scheduler_UserID == id);
            if (scheduler == null)
            {
                return NotFound();
            }

            return View(scheduler);
        }

        // POST: SchedulerHomeControl/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var scheduler = await _context.Scheduler.SingleOrDefaultAsync(m => m.Scheduler_UserID == id);
            _context.Scheduler.Remove(scheduler);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SchedulerExists(string id)
        {
            return _context.Scheduler.Any(e => e.Scheduler_UserID == id);
        }
    }
}
