using ToDoList.Models;

namespace ToDoList.ViewModels;

public class ListToDoViewModel
{
    public ICollection<ToDo> ToDos { get; set; } = new List<ToDo>();
}