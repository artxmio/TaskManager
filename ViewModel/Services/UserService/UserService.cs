using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using TaskManager.Model;
using TaskManager.Model.UserModel;

namespace TaskManager.ViewModel.Services.UserService;

public class UserService : BaseService.BaseService
{
    public UserService(ApplicationContext.ApplicationContext context) : base(context)
    {
        if (_context is not null)
        {
            _context.Users.Load();
            Data = new ObservableCollection<IEntityModel>(_context.Tasks.Local.Cast<IEntityModel>());
        }
        Selected = new User();
    }

    public override void Add()
    {
        
    }

    public override void Delete()
    {
        
    }
}
