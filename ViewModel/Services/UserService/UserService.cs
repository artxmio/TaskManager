using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows;
using TaskManager.Model;
using TaskManager.Model.UserModel;
using TaskManager.View.ModalWindows.NewUser;

namespace TaskManager.ViewModel.Services.UserService;

public class UserService : BaseService.BaseService
{
    public UserService(ApplicationContext.ApplicationContext context) : base(context)
    {
        if (_context is not null)
        {
            _context.Users.Load();
            Data = new ObservableCollection<IEntityModel>(_context.Users.Local.Cast<IEntityModel>());
        }
        Selected = new User();
    }

    public override void Add()
    {
        var viewModel = new CreateUserViewModel.CreateUserViewModel();
        var createProjectWindow = new CreateUserWindow(viewModel);

        createProjectWindow.ShowDialog();

        var dialogResult = viewModel.DialogResult;

        if (dialogResult)
        {
            _context.Users.Add(viewModel.NewUser);
            Data.Add(viewModel.NewUser);
        }
    }

    public override void Delete()
    {
        if (Selected is not null)
        {
            _context.Users.Remove((User)Selected);
            Data.Remove((User)Selected);
        }
        else
        {
            MessageBox.Show("Please, select a user", "Error", MessageBoxButton.OK);
        }
    }
}
