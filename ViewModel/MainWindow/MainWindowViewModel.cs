using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using TaskManager.Model.ProjectModel;
using TaskManager.View.ModalWindows;

namespace TaskManager.ViewModel.MainWindow;

public class MainWindowViewModel : IMainWindowViewModel
{
    private ApplicationContext.ApplicationContext _context = new ApplicationContext.ApplicationContext();

    public ObservableCollection<Project> Data { get; set; }

    public ICommand CloseCommand { get; set; }
    public ICommand CreateProjectCommand { get; set; }
    public ICommand DeleteProjectCommand { get; set; }

    public Project SelectedProject { get; set; }

    public MainWindowViewModel()
    {
        Data = new ObservableCollection<Project>();

        CloseCommand = new RelayCommand.RelayCommand(o => CloseWindow((Window)o));
        CreateProjectCommand = new RelayCommand.RelayCommand(o => CreateProject());
        DeleteProjectCommand = new RelayCommand.RelayCommand(o => DeleteProject());

        if (_context is not null)
        {
            _context.Projects.Load();
            Data = _context.Projects.Local.ToObservableCollection();
        }
    }

    private void CreateProject()
    {
        var viewModel = new CreateProjectViewModel.CreateProjectViewModel();
        var createProjectWindow = new CreateProjectWindow(viewModel);

        createProjectWindow.ShowDialog();

        var dialogResult = viewModel.DialogResult;

        if (dialogResult)
        {
            _context.Projects.Add(viewModel.NewProject);
            _context.SaveChanges();
        }
    }

    private void DeleteProject()
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

    private void CloseWindow(Window window)
    {
        window?.Close();
    }
}
