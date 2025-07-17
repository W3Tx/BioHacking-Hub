using System.ComponentModel.DataAnnotations;

namespace DailyPerformanceDashboard.Models
{
    public class SupplementIntake
    {
        // ID ist der Primärschlüssel
        public int Id { get; set; }

        [Required(ErrorMessage = "name des Supplements ist erforderlich.")]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Zeitpunkt der Einnahme ist erforderlich.")]
        [StringLength(50)]
        public string TimeOfDay { get; set; } = string.Empty;

        public bool IsTaken { get; set; }

        public DateTime Date { get; set; }
    }
}
