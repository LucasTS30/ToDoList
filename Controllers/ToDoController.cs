using Microsoft.AspNetCore.Mvc;
using ToDoList.Contexts;
using ToDoList.Models;
using ToDoList.ViewModels;

namespace ToDoList.Controllers;

public class TodoController : Controller
{
    private readonly AppDbContext _context;

    public TodoController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var toDos = _context.ToDos.OrderBy(x => x.Date).ToList();
        var viewModel = new ListToDoViewModel { ToDos = toDos };
        ViewData["Title"] = "To-do List";
        return View(viewModel);
    }

    public IActionResult Delete(int id)
    {
        var toDo = _context.ToDos.Find(id);
        if (toDo is null)
        {
            return NotFound();
        }
        _context.Remove(toDo);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Create()
    {
        ViewData["Title"] = "Create a task";
        return View("Form");
    }

    [HttpPost]
    public IActionResult Create(FormToDoViewModel formToDoViewModel)
    {
        var toDo = new ToDo(formToDoViewModel.Title, formToDoViewModel.Date);
        _context.Add(toDo);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Edit(int id)
    {
        ViewData["Title"] = "Edit task";
        var toDo = _context.ToDos.Find(id);
        if (toDo is null)
        {
            return NotFound();
        }
        var editTodoViewModel = new FormToDoViewModel{Title = toDo.Title, Date = toDo.Date};
        return View("Form", editTodoViewModel);
    }

    [HttpPost]
    public IActionResult Edit(int id, FormToDoViewModel editToDoViewModel)
    {
        var toDo = _context.ToDos.Find(id);
        if (toDo is null)
        {
            return NotFound();
        }
        toDo.Title = editToDoViewModel.Title;
        toDo.Date = editToDoViewModel.Date;
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Complete(int id)
    {
        var toDo = _context.ToDos.Find(id);
        if (toDo is null)
        {
            return NotFound();
        }
        toDo.IsCompleted = true;
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

}