using Microsoft.EntityFrameworkCore;

namespace DailyPerformanceDashboard.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<TaskItem> Tasks { get; set; }
        public DbSet<TrainingBlock> TrainingBlocks { get; set; }
        public DbSet<SupplementIntake> Supplements { get; set; }
        public DbSet<JournalEntry> JournalEntries { get; set; }
        public DbSet<KnowledgeSnippet> KnowledgeSnippets { get; set; }
        public DbSet<WaterIntake> WaterIntakes { get; set; }
    }
}