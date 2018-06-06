using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheWhatever.Data;
using TheWhatever.Models;

namespace TheWhatever.Controllers
{
    public class BlurbModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BlurbModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BlurbModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.BlurbModel.ToListAsync());
        }

        // GET: BlurbModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blurbModel = await _context.BlurbModel
                .SingleOrDefaultAsync(m => m.ID == id);
            if (blurbModel == null)
            {
                return NotFound();
            }

            return View(blurbModel);
        }

        // GET: BlurbModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BlurbModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,OwnerID,text")] BlurbModel blurbModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(blurbModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(blurbModel);
        }

        // GET: BlurbModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blurbModel = await _context.BlurbModel.SingleOrDefaultAsync(m => m.ID == id);
            if (blurbModel == null)
            {
                return NotFound();
            }
            return View(blurbModel);
        }

        // POST: BlurbModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,OwnerID,text")] BlurbModel blurbModel)
        {
            if (id != blurbModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(blurbModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlurbModelExists(blurbModel.ID))
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
            return View(blurbModel);
        }

        // GET: BlurbModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blurbModel = await _context.BlurbModel
                .SingleOrDefaultAsync(m => m.ID == id);
            if (blurbModel == null)
            {
                return NotFound();
            }

            return View(blurbModel);
        }

        // POST: BlurbModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blurbModel = await _context.BlurbModel.SingleOrDefaultAsync(m => m.ID == id);
            _context.BlurbModel.Remove(blurbModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BlurbModelExists(int id)
        {
            return _context.BlurbModel.Any(e => e.ID == id);
        }
    }
}
