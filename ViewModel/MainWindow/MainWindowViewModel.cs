using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using TaskManager.Model.ProjectModel;
using TaskManager.Model.UserModel;
using TaskManager.View.ModalWindows;
using TaskManager.ViewModel.Services.ProjectService;

namespace TaskManager.ViewModel.MainWindow;

public class MainWindowViewModel : IMainWindowViewModel, INotifyPropertyChanged
{
    private readonly ApplicationContext.ApplicationContext _context = new ApplicationContext.ApplicationContext();
    private readonly ProjectService _projectService;

    public event PropertyChangedEventHandler? PropertyChanged;

    public ObservableCollection<Model.TaskModel.Task> TasksData { get; set; }
    public ObservableCollection<User> UsersData { get; set; }
    public ProjectService ProjectService
    {
        get => _projectService;
    }

    public ICommand CloseCommand { get; set; }
    public ICommand CreateProjectCommand { get; set; }
    public ICommand DeleteProjectCommand { get; set; }
    public ICommand SaveChangesCommand { get; set; }

    public MainWindowViewModel()
    {
        TasksData = [];
        UsersData = [];

        if (_context is not null)
        {
            _context.Tasks.Load();
            _context.Users.Load();
            TasksData = _context.Tasks.Local.ToObservableCollection();
            UsersData = _context.Users.Local.ToObservableCollection();
        }
        else if (_context is null)
        {
            throw new NullReferenceException();
        }

        _projectService = new ProjectService(_context);

        CloseCommand = new RelayCommand.RelayCommand(o => CloseWindow((Window)o));
        CreateProjectCommand = new RelayCommand.RelayCommand(o => _projectService.CreateProject());
        DeleteProjectCommand = new RelayCommand.RelayCommand(o => _projectService.DeleteProject());
        SaveChangesCommand = new RelayCommand.RelayCommand(o => _projectService.SaveProjectChanges());
    }

    private static void CloseWindow(Window window)
    {
        var result = MessageBox.Show("Are you sure you want to exit?", "Attention", MessageBoxButton.YesNo);

        if (result == MessageBoxResult.Yes)
        {
            window?.Close();
        }
    }

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
