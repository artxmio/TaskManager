using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows;
using TaskManager.Model;
using TaskManager.Model.ProjectModel;
using TaskManager.View.ModalWindows.NewTask;

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
        var projects = new ObservableCollection<IEntityModel>(_context.Projects.Local.ToObservableCollection().Cast<IEntityModel>());
        var users = new ObservableCollection<IEntityModel>(_context.Users.Local.ToObservableCollection().Cast<IEntityModel>());

        var viewModel = new CreateTaskViewModel.CreateTaskViewModel(projects, users);
        var createProjectWindow = new CreateTaskWindow(viewModel);

        createProjectWindow.ShowDialog();

        var dialogResult = viewModel.DialogResult;

        if (dialogResult)
        {
            _context.Tasks.Add(viewModel.NewTask);
            Data.Add(viewModel.NewTask);
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
