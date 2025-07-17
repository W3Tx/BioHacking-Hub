using System.ComponentModel.DataAnnotations;

namespace DailyPerformanceDashboard.Models
{
    public class JournalEntry
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Eintrag darf nicht leer sein.")]
        [StringLength(2000, ErrorMessage = "Der Text darf maximal 2000 Zeichen umfassen.")]
        public string Content { get; set; } = string.Empty;

        public DateTime Date { get; set; }
    }
}
