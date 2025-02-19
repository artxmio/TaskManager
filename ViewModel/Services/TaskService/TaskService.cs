using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace TaskManager.ViewModel.Services.TaskService;

public class TaskService
{
    private readonly ApplicationContext.ApplicationContext _context;

    public ObservableCollection<Model.TaskModel.Task> TasksData { get; set; }

    public Model.TaskModel.Task? SelectedTask { get; set; }

    public TaskService(ApplicationContext.ApplicationContext context)
    {
        _context = context;
        if (context is null)
        {
            TasksData = [];
        }
        else
        {
            _context.Tasks.Load();
            TasksData = _context.Tasks.Local.ToObservableCollection();
        }
    }

    public void CreateTask()
    {
        
    }

    public void DeleteTask()
    {
        
    }

    public void SaveTaskChanges()
    {
        
    }
}
