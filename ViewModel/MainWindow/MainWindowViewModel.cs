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

    public MainWindowViewModel()
    {
        Data = new ObservableCollection<Project>();
        
        CloseCommand = new RelayCommand.RelayCommand(o => CloseWindow((Window)o));
        CreateProjectCommand = new RelayCommand.RelayCommand(o => CreateProject());

        if (_context is not null)
        {
            _context.Projects.Load();
            Data = _context.Projects.Local.ToObservableCollection();
        }
    }

    private void CreateProject()
    {
        var createProjectWindow = new CreateProjectWindow();

        createProjectWindow.ShowDialog();
    }

    private void CloseWindow(Window window)
    {
        window?.Close();
    }
}
