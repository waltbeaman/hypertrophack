using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hypertrophack.Data;
using Hypertrophack.Models;

namespace Hypertrophack.Controllers
{
    public class CompletedExercisesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CompletedExercisesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<SelectListItem> MuscleGroups { get; } = new List<SelectListItem>
        {
            new SelectListItem {Value = "Chest", Text = "Chest"},
            new SelectListItem {Value = "Back", Text = "Back"},
            new SelectListItem {Value = "Legs", Text = "Legs"},
            new SelectListItem {Value = "Arms", Text = "Arms"},
            new SelectListItem {Value = "Shoulders", Text = "Shoulders"},
        };

        // GET: CompletedExercises
        public async Task<IActionResult> Index()
        {
            return View(await _context.CompletedExercises.ToListAsync());
        }

        // GET: CompletedExercises/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.MuscleGroups = MuscleGroups;
            return View();
        }

        // POST: CompletedExercises/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Exercise,MuscleGroup,Sets,Date")] CompletedExercise completedExercise)
        {
            ViewBag.MuscleGroups = MuscleGroups;

            _context.Add(completedExercise);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            // Figure out why ViewBag is sending null value for muscle group
            //if (ModelState.IsValid)
            //{
            //    _context.Add(completedExercise);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(completedExercise);
        }

        // GET: CompletedExercises/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.MuscleGroups = MuscleGroups;

            if (id == null || _context.CompletedExercises == null)
            {
                return NotFound();
            }

            var completedExercise = await _context.CompletedExercises.FindAsync(id);
            if (completedExercise == null)
            {
                return NotFound();
            }

            return View(completedExercise);
        }

        // POST: CompletedExercises/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Exercise,MuscleGroup,Sets,Date")] CompletedExercise completedExercise)
        {
            ViewBag.MuscleGroups = MuscleGroups;

            if (id != completedExercise.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(completedExercise);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompletedExerciseExists(completedExercise.Id))
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

            return View(completedExercise);
        }

        // GET: CompletedExercises/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            ViewBag.MuscleGroups = MuscleGroups;

            if (id == null || _context.CompletedExercises == null)
            {
                return NotFound();
            }

            var completedExercise = await _context.CompletedExercises.FirstOrDefaultAsync(m => m.Id == id);

            if (completedExercise == null)
            {
                return NotFound();
            }
            else
            {
                return View(completedExercise);
            }

        }

        // POST: CompletedExercises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            ViewBag.MuscleGroups = MuscleGroups;

            if (_context.CompletedExercises == null)
            {
                return Problem("Entity set 'ApplicationDbContext.CompletedExercises'  is null.");
            }

            var completedExercise = await _context.CompletedExercises.FindAsync(id);

            if (completedExercise != null)
            {
                _context.CompletedExercises.Remove(completedExercise);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompletedExerciseExists(int id)
        {
          return _context.CompletedExercises.Any(e => e.Id == id);
        }
    }
}
