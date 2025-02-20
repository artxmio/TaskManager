using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows;
using TaskManager.Model;
using TaskManager.Model.ProjectModel;
using TaskManager.View.ModalWindows.NewProject;

namespace TaskManager.ViewModel.Services.ProjectService;

public class ProjectService : BaseService.BaseService
{
    private readonly TaskService.TaskService _taskService;

    public ProjectService(ApplicationContext.ApplicationContext context, TaskService.TaskService taskService) : base(context)
    {
        if (context is not null)
        {
            _context.Projects.Load();
            Data = new ObservableCollection<IEntityModel>(context.Projects.Local.Cast<IEntityModel>());
        }

        _taskService = taskService;
    }

    public override void Add()
    {
        var viewModel = new CreateProjectViewModel.CreateProjectViewModel();
        var createProjectWindow = new CreateProjectWindow(viewModel);

        createProjectWindow.ShowDialog();

        var dialogResult = viewModel.DialogResult;

        if (dialogResult)
        {
            _context.Projects.Add(viewModel.NewProject);
            Data.Add(viewModel.NewProject);
            _context.SaveChanges();
        }
    }

    public override void Delete()
    {
        if (Selected is not null)
        {
            _context.Projects.Remove((Project)Selected);
            Data.Remove((Project)Selected);
            _context.SaveChanges();
        }
        else
        {
            MessageBox.Show("Please, select a project", "Error", MessageBoxButton.OK);
        }
    }
}
