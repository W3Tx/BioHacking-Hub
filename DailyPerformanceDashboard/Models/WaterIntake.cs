using System.ComponentModel.DataAnnotations;

namespace DailyPerformanceDashboard.Models
{
    public class WaterIntake
    {
        public int Id { get; set; }
        [Range(0, 20, ErrorMessage = "Maximal 20 Einheiten pro Tag")]
        public int Glasses { get; set; } = 0;
        public DateTime Date { get; set; }
    }
}
