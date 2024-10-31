using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TodoList.Models;

namespace TodoList.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private static List<TodoItem> _todos = new();


    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View(_todos);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(string task)
    {
        Console.WriteLine("adding task....");
        
        if (!string.IsNullOrEmpty(task))
        {
            _todos.Add(new TodoItem 
            { 
                Id = _todos.Count + 1, 
                Task = task 
            });
        }

        printRlist();
        Console.WriteLine("done adding task....");
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        var todo = _todos.FirstOrDefault(t => t.Id == id);
        if (todo != null)
        {
            _todos.Remove(todo);
        }
        return RedirectToAction("Index");
    }

        public void printRlist() {
            Console.WriteLine("Current Equipment Requests:");
            foreach (var request in _todos)
            {
                Console.WriteLine($"Id: {request.Id}, Task: {request.Task}");
            }

        }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
