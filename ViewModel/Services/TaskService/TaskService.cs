using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows;
using TaskManager.Model;
using TaskManager.View.ModalWindows.NewUser;

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
        var viewModel = new CreateUserViewModel.CreateUserViewModel();
        var createProjectWindow = new CreateUserWindow(viewModel);

        createProjectWindow.ShowDialog();

        var dialogResult = viewModel.DialogResult;

        if (dialogResult)
        {
            _context.Users.Add(viewModel.NewUser);
        }
    }

    public override void Delete()
    {
        if (Selected is not null)
        {
            _context.Tasks.Remove((Model.TaskModel.Task)Selected);
            Data.Remove((Model.TaskModel.Task)Selected);
        }
        else
        {
            MessageBox.Show("Please, select a task", "Error", MessageBoxButton.OK);
        }
    }
}
