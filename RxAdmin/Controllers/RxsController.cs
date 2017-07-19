using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RxAdmin.Data;
using RxAdmin.Models;
using Microsoft.AspNetCore.Authorization;

namespace RxAdmin.Controllers
{
    [Authorize]
    public class RxsController : Controller
    {
        private readonly HospitalContext _context;

        public RxsController(HospitalContext context)
        {
            _context = context;    
        }

        // GET: Rxs
        public async Task<IActionResult> Index()
        {
            var hospitalContext = _context.Rxs.Include(r => r.Patient);
            return View(await hospitalContext.ToListAsync());
        }

        // GET: Rxs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rx = await _context.Rxs
                .Include(r => r.Patient)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (rx == null)
            {
                return NotFound();
            }

            return View(rx);
        }

        // GET: Rxs/Create
        public IActionResult Create()
        {
            ViewData["PatientID"] = new SelectList(_context.Patients, "ID", "ID");
            return View();
        }

        // POST: Rxs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,PatientID,Email,FillDate,RefillDate,RxDose,RxName,Text")] Rx rx)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rx);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["PatientID"] = new SelectList(_context.Patients, "ID", "ID", rx.PatientID);
            return View(rx);
        }

        // GET: Rxs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rx = await _context.Rxs.SingleOrDefaultAsync(m => m.ID == id);
            if (rx == null)
            {
                return NotFound();
            }
            ViewData["PatientID"] = new SelectList(_context.Patients, "ID", "ID", rx.PatientID);
            return View(rx);
        }

        // POST: Rxs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,PatientID,Email,FillDate,RefillDate,RxDose,RxName,Text")] Rx rx)
        {
            if (id != rx.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rx);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RxExists(rx.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["PatientID"] = new SelectList(_context.Patients, "ID", "ID", rx.PatientID);
            return View(rx);
        }

        // GET: Rxs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rx = await _context.Rxs
                .Include(r => r.Patient)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (rx == null)
            {
                return NotFound();
            }

            return View(rx);
        }

        // POST: Rxs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rx = await _context.Rxs.SingleOrDefaultAsync(m => m.ID == id);
            _context.Rxs.Remove(rx);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool RxExists(int id)
        {
            return _context.Rxs.Any(e => e.ID == id);
        }
    }
}
