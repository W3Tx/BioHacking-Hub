using System.ComponentModel.DataAnnotations;

namespace DailyPerformanceDashboard.Models
{
    public class TaskItem
    {
        // ID ist der Primärschlüssel
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Ein Titel ist erforderlich")]
        [StringLength(100, ErrorMessage = "Der Titel darf maximal 100 Zeichen lang sein.")]
        public string Title { get; set; } = string.Empty;
        
        public DateTime Date { get; set; }

        public bool IsDone { get; set; } = false;
    }
}
