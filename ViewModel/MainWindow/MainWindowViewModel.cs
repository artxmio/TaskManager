using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using TaskManager.Model.ProjectModel;
using TaskManager.ViewModel.Services.ProjectService;
using TaskManager.ViewModel.Services.TaskService;
using TaskManager.ViewModel.Services.UserService;

namespace TaskManager.ViewModel.MainWindow;

public class MainWindowViewModel : IMainWindowViewModel, INotifyPropertyChanged
{
    private readonly ApplicationContext.ApplicationContext _context = new ApplicationContext.ApplicationContext();
    private readonly ProjectService _projectService;
    private readonly TaskService _taskService;
    private readonly UserService _userService;

    public ProjectService ProjectService
    {
        get => _projectService;
    }
    public TaskService TaskService
    {
        get => _taskService;
    }
    public UserService UserService
    {
        get => _userService;
    }

    public ICommand CloseCommand { get; set; }

    public ICommand CreateProjectCommand { get; set; }
    public ICommand DeleteProjectCommand { get; set; }

    public ICommand CreateUserCommand { get; set; }
    public ICommand DeleteUserCommand { get; set; }

    public ICommand CreateTaskCommand { get; set; }
    public ICommand DeleteTaskCommand { get; set; }

    public ICommand SaveChangesCommand { get; set; }

    public MainWindowViewModel()
    {
        _projectService = new ProjectService(_context, TaskService);
        _userService = new UserService(_context);
        _taskService = new TaskService(_context, ProjectService, UserService);

        CloseCommand = new RelayCommand.RelayCommand(o => CloseWindow((Window)o));

        CreateProjectCommand = new RelayCommand.RelayCommand(o => _projectService.Add());
        DeleteProjectCommand = new RelayCommand.RelayCommand(o => _projectService.Delete());

        CreateUserCommand = new RelayCommand.RelayCommand(o => _userService.Add());
        DeleteUserCommand = new RelayCommand.RelayCommand(o => _userService.Delete());

        CreateTaskCommand = new RelayCommand.RelayCommand(o => _taskService.Add());
        DeleteTaskCommand = new RelayCommand.RelayCommand(o => _taskService.Delete());
    }

    private static void CloseWindow(Window window)
    {
        var result = MessageBox.Show("Are you sure you want to exit?", "Attention", MessageBoxButton.YesNo);

        if (result == MessageBoxResult.Yes)
        {
            window?.Close();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
