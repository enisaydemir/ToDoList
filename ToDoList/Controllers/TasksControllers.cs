using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class TasksController : Controller // İsim "TasksController" olarak düzeltildi
    {
        private readonly AppDbContext _context;

        public TasksController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var tasks = await _context.Tasks.ToListAsync();
            return View(tasks);
        }

        [HttpPost]
        public async Task<IActionResult> Add(string title)
        {
            if (!string.IsNullOrEmpty(title))
            {
                _context.Tasks.Add(new TaskModel { Description = title, IsDone = false });
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Toggle(int id)
        {
            var task = await _context.Tasks.FindAsync(id); // Hata düzeltildi: FindAsync(id)
            if (task != null)
            {
                task.IsDone = !task.IsDone;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}