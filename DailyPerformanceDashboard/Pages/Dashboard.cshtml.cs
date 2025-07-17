using DailyPerformanceDashboard.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DailyPerformanceDashboard.Pages
{
    public class DashboardModel : PageModel
    {
        private readonly AppDbContext _context;

        public DashboardModel(AppDbContext context)
        {
            _context = context;
        }

        // Daten für die Anzeige
        public List<TaskItem> TodayTasks { get; set; } = new();
        public List<SupplementIntake> TodaySupplements { get; set; } = new();
        public List<TrainingBlock> TodayTrainings { get; set; } = new();
        public JournalEntry? TodayReflection { get; set; }
        public KnowledgeSnippet? SnippetOfTheDay { get; set; }

        // Statistiken
        public int DayStreak { get; set; }
        public int TasksCompleted { get; set; }
        public int TasksTotal { get; set; }
        public int TrainingDays { get; set; }
        public int WaterGlasses { get; set; }

        public async Task OnGetAsync()
        {
            var today = DateTime.Today;

            // Heutige Daten laden
            TodayTasks = await _context.Tasks.Where(t => t.Date == today).ToListAsync();
            TodaySupplements = await _context.Supplements.Where(s => s.Date == today).ToListAsync();
            TodayTrainings = await _context.TrainingBlocks.Where(t => t.Date == today).ToListAsync();
            TodayReflection = await _context.JournalEntries.FirstOrDefaultAsync(j => j.Date == today);

            // Aufgaben-Zähler
            TasksTotal = TodayTasks.Count;
            TasksCompleted = TodayTasks.Count(t => t.IsDone);

            // Trainings-Tage insgesamt (alle Tage mit Einträgen)
            TrainingDays = await _context.TrainingBlocks
                .Select(t => t.Date.Date)
                .Distinct()
                .CountAsync();

            // Wasser heute (Gläser)
            WaterGlasses = await _context.WaterIntakes
                .Where(w => w.Date == today)
                .Select(w => w.Glasses)
                .FirstOrDefaultAsync();

            // Tagesstreak berechnen (wie viele Tage in Folge Journal geschrieben)
            DayStreak = await CalculateDayStreakAsync();

            // Snippets laden (falls noch keine existieren, füge welche ein)
            if (!await _context.KnowledgeSnippets.AnyAsync())
            {
                _context.KnowledgeSnippets.AddRange(new[]
                {
                    new KnowledgeSnippet { Title = "Pomodoro-Technik", ShortText = "Arbeite 25 Minuten fokussiert und mache danach 5 Minuten Pause.", MoreLink = "https://de.wikipedia.org/wiki/Pomodoro-Technik" },
                    new KnowledgeSnippet { Title = "Wasser trinken", ShortText = "Dein Gehirn funktioniert besser, wenn du genug trinkst – ca. 2 Liter pro Tag." },
                    new KnowledgeSnippet { Title = "Tief schlafen", ShortText = "7–9 Stunden Schlaf fördern Gedächtnis, Fokus und Erholung." },
                    new KnowledgeSnippet { Title = "Morgens Bewegung", ShortText = "Schon 10 Minuten Spazierengehen am Morgen regen deine Konzentration an." },
                    new KnowledgeSnippet { Title = "Ziele visualisieren", ShortText = "Ein klarer Fokus auf dein 'Warum' steigert Motivation und Ausdauer." }
                });

                await _context.SaveChangesAsync();
            }

            // Zufälliges Tageswissen auswählen
            var snippets = await _context.KnowledgeSnippets.ToListAsync();
            if (snippets.Any())
            {
                var random = new Random();
                SnippetOfTheDay = snippets[random.Next(snippets.Count)];
            }
        }

        // Berechnet wie viele Tage in Folge ein Journal-Eintrag gemacht wurde
        private async Task<int> CalculateDayStreakAsync()
        {
            int streak = 0;
            var daysWithEntry = await _context.JournalEntries
                .Select(j => j.Date.Date)
                .Distinct()
                .ToListAsync();

            var currentDate = DateTime.Today;
            while (daysWithEntry.Contains(currentDate))
            {
                streak++;
                currentDate = currentDate.AddDays(-1);
            }

            return streak;
        }

        // Wird aufgerufen, wenn auf „+1 Glas“ Button geklickt wird
        public async Task<IActionResult> OnPostAddWaterAsync()
        {
            var today = DateTime.Today;

            // Gibt es schon einen Eintrag für heute?
            var existing = await _context.WaterIntakes.FirstOrDefaultAsync(w => w.Date == today);

            if (existing != null)
            {
                existing.Glasses++; // Anzahl erhöhen
            }
            else
            {
                // Neuer Eintrag
                _context.WaterIntakes.Add(new WaterIntake { Date = today, Glasses = 1 });
            }

            await _context.SaveChangesAsync();
            return RedirectToPage(); // Seite neu laden
        }

        // === Einträge löschen ===
        public async Task<IActionResult> OnPostDeleteTaskAsync(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteTrainingAsync(int id)
        {
            var training = await _context.TrainingBlocks.FindAsync(id);
            if (training != null)
            {
                _context.TrainingBlocks.Remove(training);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteSupplementAsync(int id)
        {
            var supplement = await _context.Supplements.FindAsync(id);
            if (supplement != null)
            {
                _context.Supplements.Remove(supplement);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteReflectionAsync(int id)
        {
            var reflection = await _context.JournalEntries.FindAsync(id);
            if (reflection != null)
            {
                _context.JournalEntries.Remove(reflection);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}
