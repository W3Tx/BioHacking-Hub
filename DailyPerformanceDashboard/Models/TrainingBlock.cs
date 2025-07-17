using System.ComponentModel.DataAnnotations;

namespace DailyPerformanceDashboard.Models
{
    public class TrainingBlock
    {
        // ID ist der Primärschlüssel
        public int Id { get; set; }

        [Required(ErrorMessage = "Eine Name ist erforderlich.")]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [StringLength(1000, ErrorMessage = "Die Beschreibung der Übungen darf maximal 1000 Zeichen lang sein.")]
        public string Exercises { get; set; } = string.Empty;

        public DateTime Date { get; set; }
    }
}
