using System.ComponentModel.DataAnnotations;

namespace DailyPerformanceDashboard.Models
{
    public class KnowledgeSnippet
    {
        // ID ist der Primärschlüssel
        public int Id { get; set; }

        [Required(ErrorMessage = "Ein Titel ist erforderlich.")]
        [StringLength(150)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Kurzer Text ist erforderlich.")]
        [StringLength(500)]
        public string ShortText { get; set; } = string.Empty;

        [Url(ErrorMessage = "Der Link muss eine gültige URL sein.")]
        public string? MoreLink { get; set; }
    }
}
