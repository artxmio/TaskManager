using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows;
using TaskManager.Model.ProjectModel;
using TaskManager.View.ModalWindows;

namespace TaskManager.ViewModel.Services.ProjectService;

public class ProjectService
{
    private readonly ApplicationContext.ApplicationContext _context;

    public ObservableCollection<Project> ProjectsData { get; set; }

    public Project? SelectedProject { get; set; }

    public ProjectService(ApplicationContext.ApplicationContext context)
    {
        _context = context;
        if (context is null)
        {
            ProjectsData = [];
        }
        else
        {
            _context.Projects.Load();
            ProjectsData = _context.Projects.Local.ToObservableCollection();
        }
    }

    public void CreateProject()
    {
        var viewModel = new CreateProjectViewModel.CreateProjectViewModel();
        var createProjectWindow = new CreateProjectWindow(viewModel);

        createProjectWindow.ShowDialog();

        var dialogResult = viewModel.DialogResult;

        if (dialogResult)
        {
            _context.Projects.Add(viewModel.NewProject);
        }
    }

    public void DeleteProject()
    {
        if (SelectedProject is not null)
        {
            _context.Projects.Remove(SelectedProject);
        }
        else
        {
            MessageBox.Show("Please, select a project", "Error", MessageBoxButton.OK);
        }
    }

    public void SaveProjectChanges()
    {
        _context.SaveChanges();
        MessageBox.Show("Changes was saved", "Success", MessageBoxButton.OK);
    }
}
