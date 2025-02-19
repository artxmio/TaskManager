using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows;
using TaskManager.Model;
using TaskManager.Model.ProjectModel;
using TaskManager.View.ModalWindows;

namespace TaskManager.ViewModel.Services.ProjectService;

public class ProjectService : BaseService.BaseService
{
    public ProjectService(ApplicationContext.ApplicationContext context) : base(context)
    {
        if (context is not null)
        {
            _context.Projects.Load();
            Data = new ObservableCollection<IEntityModel>(context.Projects.Local.Cast<IEntityModel>());
        }

        Selected = new Project();
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
        }
    }

    public override void Delete()
    {
        if (Selected is not null)
        {
            _context.Projects.Remove((Project)Selected);
        }
        else
        {
            MessageBox.Show("Please, select a project", "Error", MessageBoxButton.OK);
        }
    }
}
