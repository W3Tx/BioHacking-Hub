using DailyPerformanceDashboard.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DailyPerformanceDashboard.Pages
{
    public class DailyInputModel : PageModel
    {
        private readonly AppDbContext _context;

        public DailyInputModel(AppDbContext context)
        {
            _context = context;
        }

        // Neue Eingaben (aus Formularen)
        public TaskItem NewTask { get; set; } = new();
        public TrainingBlock NewTraining { get; set; } = new();
        public SupplementIntake NewSupplement { get; set; } = new();
        public JournalEntry NewReflection { get; set; } = new();

        // Für Wasseranzeige
        public WaterIntake? TodayWater { get; set; }

        // Bereits vorhandene Einträge
        public List<TaskItem> TodayTasks { get; set; } = new();
        public List<TrainingBlock> TodayTrainings { get; set; } = new();
        public List<SupplementIntake> TodaySupplements { get; set; } = new();
        public JournalEntry? TodayReflection { get; set; }

        // Beim Laden der Seite
        public async Task OnGetAsync()
        {
            var today = DateTime.Today;

            TodayTasks = await _context.Tasks.Where(t => t.Date == today).ToListAsync();
            TodayTrainings = await _context.TrainingBlocks.Where(t => t.Date == today).ToListAsync();
            TodaySupplements = await _context.Supplements.Where(s => s.Date == today).ToListAsync();
            TodayReflection = await _context.JournalEntries.FirstOrDefaultAsync(j => j.Date == today);
            TodayWater = await _context.WaterIntakes.FirstOrDefaultAsync(w => w.Date == today);
        }

        // === Aufgaben hinzufügen ===
        public async Task<IActionResult> OnPostAddTaskAsync([Bind(Prefix = "NewTask")] TaskItem task)
        {
            task.Date = DateTime.Today;

            if (!ModelState.IsValid)
            {
                await OnGetAsync();
                return Page();
            }

            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return RedirectToPage();
        }

        // === Training hinzufügen ===
        public async Task<IActionResult> OnPostAddTrainingAsync([Bind(Prefix = "NewTraining")] TrainingBlock training)
        {
            training.Date = DateTime.Today;

            if (!ModelState.IsValid)
            {
                await OnGetAsync();
                return Page();
            }

            _context.TrainingBlocks.Add(training);
            await _context.SaveChangesAsync();
            return RedirectToPage();
        }

        // === Supplement hinzufügen ===
        public async Task<IActionResult> OnPostAddSupplementAsync([Bind(Prefix = "NewSupplement")] SupplementIntake supplement)
        {
            supplement.Date = DateTime.Today;

            if (!ModelState.IsValid)
            {
                await OnGetAsync();
                return Page();
            }

            _context.Supplements.Add(supplement);
            await _context.SaveChangesAsync();
            return RedirectToPage();
        }

        // === Reflektion hinzufügen ===
        public async Task<IActionResult> OnPostAddReflectionAsync([Bind(Prefix = "NewReflection")] JournalEntry reflection)
        {
            reflection.Date = DateTime.Today;

            bool gibtSchonEintrag = await _context.JournalEntries.AnyAsync(j => j.Date == reflection.Date);
            if (gibtSchonEintrag)
            {
                ModelState.AddModelError("", "Es existiert bereits ein Eintrag für heute.");
                await OnGetAsync();
                return Page();
            }

            if (!ModelState.IsValid)
            {
                await OnGetAsync();
                return Page();
            }

            _context.JournalEntries.Add(reflection);
            await _context.SaveChangesAsync();
            return RedirectToPage();
        }
    }
}
