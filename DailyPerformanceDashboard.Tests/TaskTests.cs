using DailyPerformanceDashboard.Models;

namespace DailyPerformanceDashboard.Tests
{
    public class TaskTests
    {
        [Fact]
        public void Should_Create_TaskItem_With_Valid_Title()
        {
            var task = new TaskItem
            {
                Title = "Tagesbericht schreiben",
                Date = DateTime.Today,
                IsDone = false
            };

            Assert.Equal("Tagesbericht schreiben", task.Title);
            Assert.False(task.IsDone);
        }
    }
}
