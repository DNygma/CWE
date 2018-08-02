using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CWE.Models;
using static CWE.Models.CurrencyQueue;
using System.Collections;
using System.Threading;

namespace CWE.Controllers
{
    public class RequestController : Controller
    {
        private readonly CEA_DBContext _context;

        public void CallSchedulerThread()
        {
            CEA_DBContext context;
            context = _context;
            CWE.Services.Scheduling Start = new CWE.Services.Scheduling(_context);
            

            while (true)
            {
                Thread.Sleep(10000);
                Start.RunScheduler(context);
            }
        }

        public RequestController(CEA_DBContext context)
        {
            _context = context;
            ThreadStart scheduleref = new ThreadStart(CallSchedulerThread);
            Thread schedThread = new Thread(scheduleref);
            schedThread.Name = "Currency Scheduler Thread";
            schedThread.Start();
        }

        //public RequestController()
        //{

        //}

        // GET: Request
        public async Task<IActionResult> Index()
        {

            return View(await _context.Request.ToListAsync());
        }

        public ActionResult InputEmail()
        {
            return View();
        }

        // GET: Request/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.Request
                .SingleOrDefaultAsync(m => m.Request_ID == id);
            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

        // GET: Request/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Request/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Request_ID,Request_Pair,Request_TargetRte,Email")] Request request)
        {
            if (ModelState.IsValid)
            {
                _context.Add(request);
                CurrencyQueue newReq = new CurrencyQueue
                {
                    Queue_UserID = request.Request_ID,
                    Queue_CurrencyPair = request.Request_Pair,
                    Queue_Target = request.Request_TargetRte
                };
                AddQueueTop(newReq);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(request);
        }

        // GET: Request/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.Request.SingleOrDefaultAsync(m => m.Request_ID == id);
            if (request == null)
            {
                return NotFound();
            }
            return View(request);
        }

        // POST: Request/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Request_ID,Request_Pair,Request_TargetRte,Email")] Request request)
        {
            if (id != request.Request_ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(request);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequestExists(request.Request_ID))
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
            return View(request);
        }

        // GET: Request/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var request = await _context.Request
                .SingleOrDefaultAsync(m => m.Request_ID == id);
            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

        // POST: Request/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var request = await _context.Request.SingleOrDefaultAsync(m => m.Request_ID == id);
            _context.Request.Remove(request);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequestExists(string id)
        {
            return _context.Request.Any(e => e.Request_ID == id);
        }
    }
}
