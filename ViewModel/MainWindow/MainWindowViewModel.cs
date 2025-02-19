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
using TaskManager.ViewModel.Services.TaskService;
using TaskManager.ViewModel.Services.UserService;

namespace TaskManager.ViewModel.MainWindow;

public class MainWindowViewModel : IMainWindowViewModel, INotifyPropertyChanged
{
    private readonly ApplicationContext.ApplicationContext _context = new ApplicationContext.ApplicationContext();
    private readonly ProjectService _projectService;
    private readonly TaskService _taskService;
    private UserService _userService;

    public event PropertyChangedEventHandler? PropertyChanged;

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
    public ICommand SaveChangesCommand { get; set; }

    public MainWindowViewModel()
    {
        _projectService = new ProjectService(_context);
        _taskService = new TaskService(_context);
        _userService = new UserService(_context);

        CloseCommand = new RelayCommand.RelayCommand(o => CloseWindow((Window)o));
        CreateProjectCommand = new RelayCommand.RelayCommand(o => _projectService.Add());
        DeleteProjectCommand = new RelayCommand.RelayCommand(o => _projectService.Delete());
        SaveChangesCommand = new RelayCommand.RelayCommand(o => _projectService.Save());
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
