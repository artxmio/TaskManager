using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using TaskManager.Model;

namespace TaskManager.ViewModel.Services.TaskService;

public class TaskService : BaseService.BaseService
{
    public TaskService(ApplicationContext.ApplicationContext context) : base(context)
    {
        if (context is not null)
        {
            _context.Tasks.Load();
            Data = new ObservableCollection<IEntityModel>(context.Tasks.Local.Cast<IEntityModel>());
        }
    }

    public override void Add()
    {
        
    }

    public override void Delete()
    {
        
    }
}
