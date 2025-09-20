using System.Linq;

namespace ToDoList.Models
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();

            // Eğer görevler zaten varsa, tekrar ekleme
            if (context.Tasks.Any())
                return;

            var tasks = new TaskModel[]
            {
                new TaskModel { Description = "Örnek görev 1", IsDone = false },
                new TaskModel { Description = "Örnek görev 2", IsDone = true },
                new TaskModel { Description = "Örnek görev 3", IsDone = false }
            };

            foreach (var t in tasks)
            {
                context.Tasks.Add(t);
            }

            context.SaveChanges();
        }
    }
}
