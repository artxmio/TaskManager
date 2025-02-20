using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows;
using TaskManager.Model;
using TaskManager.Model.ProjectModel;
using TaskManager.View.ModalWindows.NewTask;
using TaskManager.ViewModel.Services.ProjectService;
using TaskManager.ViewModel.Services.UserService;

namespace TaskManager.ViewModel.Services.TaskService;

public class TaskService : BaseService.BaseService
{
    private readonly ProjectService.ProjectService _projectService;
    private readonly UserService.UserService _userService;

    public TaskService(
        ApplicationContext.ApplicationContext context, 
        ProjectService.ProjectService projectService, 
        UserService.UserService userService) : base(context)
    {
        if (context is not null)
        {
            _context.Tasks.Load();
            Data = new ObservableCollection<IEntityModel>(context.Tasks.Local.Cast<IEntityModel>());
        }
        _projectService = projectService;
        _userService = userService;
    }

    public override void Add()
    {
        var projects = _projectService.Data;
        var users = _userService.Data;

        var viewModel = new CreateTaskViewModel.CreateTaskViewModel(projects, users);
        var createProjectWindow = new CreateTaskWindow(viewModel);

        createProjectWindow.ShowDialog();

        var dialogResult = viewModel.DialogResult;

        if (dialogResult)
        {
            _context.Tasks.Add(viewModel.NewTask);
            Data.Add(viewModel.NewTask);
            _context.SaveChanges();
        }
    }

    public override void Delete()
    {
        if (Selected is not null)
        {
            _context.Tasks.Remove((Model.TaskModel.Task)Selected);
            Data.Remove((Model.TaskModel.Task)Selected);
            _context.SaveChanges();
        }
        else
        {
            MessageBox.Show("Please, select a task", "Error", MessageBoxButton.OK);
        }
    }
}
