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
    public class WeeklyProgressController : Controller
    {
        private readonly ApplicationDbContext _context;

        // Get first day of week
        private readonly DateTime _weekStart = DateTime.Now.StartOfWeek(DayOfWeek.Monday);

        public WeeklyProgressController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: WeeklyProgresses
        public async Task<IActionResult> Index()
        {
            var completedExercises = await (from e in _context.CompletedExercises
                                            where e.Date >= _weekStart && e.Date <= DateTime.Now
                                            select e).ToListAsync();

            var weeklyProgress = new WeeklyProgress
            {
                WeekStart = _weekStart,
                ChestSets = completedExercises.Where(x => x.MuscleGroup == "Chest").Sum(x => x.Sets),
                BackSets = completedExercises.Where(x => x.MuscleGroup == "Back").Sum(x => x.Sets),
                LegSets = completedExercises.Where(x => x.MuscleGroup == "Legs").Sum(x => x.Sets),
                ArmSets = completedExercises.Where(x => x.MuscleGroup == "Arms").Sum(x => x.Sets),
                ShoulderSets = completedExercises.Where(x => x.MuscleGroup == "Shoulders").Sum(x => x.Sets),
            };

            // Calculate chest progress
            ViewBag.ChestPctMaint = decimal.Round((weeklyProgress.ChestSets / 5m) * 100m);
            ViewBag.ChestPctMin = decimal.Round((weeklyProgress.ChestSets / 6m) * 100m);
            ViewBag.ChestPctMax = decimal.Round((weeklyProgress.ChestSets / 20m) * 100m);

            // Calculate back progress
            ViewBag.BackPctMaint = decimal.Round((weeklyProgress.BackSets / 6m) * 100m);
            ViewBag.BackPctMin = decimal.Round((weeklyProgress.BackSets / 10m) * 100m);
            ViewBag.BackPctMax = decimal.Round((weeklyProgress.BackSets / 20m) * 100m);

            // Calculate leg progress
            ViewBag.LegPctMaint = decimal.Round((weeklyProgress.LegSets / 6m) * 100m);
            ViewBag.LegPctMin = decimal.Round((weeklyProgress.LegSets / 8m) * 100m);
            ViewBag.LegPctMax = decimal.Round((weeklyProgress.LegSets / 25m) * 100m);

            // Calculate arm progress
            ViewBag.ArmPctMaint = decimal.Round((weeklyProgress.ArmSets / 4m) * 100m);
            ViewBag.ArmPctMin = decimal.Round((weeklyProgress.ArmSets / 8m) * 100m);
            ViewBag.ArmPctMax = decimal.Round((weeklyProgress.ArmSets / 22m) * 100m);

            // Calculate shoulder progress
            if (weeklyProgress.ChestSets >= 5)
            {
                ViewBag.ShoulderPctMaint = 100m;
            }
            else
            {
                ViewBag.ShoulderPctMaint = decimal.Round((weeklyProgress.ShoulderSets / 3m) * 100m);
            }
            ViewBag.ShoulderPctMin = decimal.Round((weeklyProgress.ShoulderSets / 6m) * 100m);
            ViewBag.ShoulderPctMax = decimal.Round((weeklyProgress.ShoulderSets / 16m) * 100m);

            return View(weeklyProgress);
        }

    }
}
