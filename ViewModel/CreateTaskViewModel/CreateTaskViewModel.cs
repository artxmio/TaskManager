using System.Windows.Input;
using System.Windows;
using TaskManager.Model.ProjectModel;
using System.Collections.ObjectModel;
using TaskManager.Model;
using System.ComponentModel;
using TaskManager.Model.UserModel;

namespace TaskManager.ViewModel.CreateTaskViewModel;

public class CreateTaskViewModel : INotifyPropertyChanged
{
    private ObservableCollection<Project> _projects;
    private Project _selectedProject;

    private ObservableCollection<User> _users;
    private User _selectedUser;

    public Model.TaskModel.Task NewTask { get; set; }
    public bool DialogResult { get; set; }
    public ICommand CreateTaskCommand { get; set; }
    public ICommand CloseWindowCommand { get; set; }

    public ObservableCollection<Project> Projects
    {
        get => _projects;
        set
        {
            if (_projects != value)
            {
                _projects = value;
                OnPropertyChanged(nameof(Projects));
            }
        }
    }
    public Project SelectedProject
    {
        get => _selectedProject;
        set
        {
            if (_selectedProject != value)
            {
                _selectedProject = value;
                OnPropertyChanged(nameof(SelectedProject));
            }
        }
    }

    public ObservableCollection<User> Users
    {
        get { return _users; }
        set
        {
            if (_users != value)
            {
                _users = value;
                OnPropertyChanged(nameof(Users));
            }
        }
    }

    public User SelectedUser
    {
        get { return _selectedUser; }
        set
        {
            if (_selectedUser != value)
            {
                _selectedUser = value;
                OnPropertyChanged(nameof(SelectedUser));
            }
        }
    }

    public CreateTaskViewModel(ObservableCollection<IEntityModel> projects, ObservableCollection<IEntityModel> users)
    {
        NewTask = new Model.TaskModel.Task();

        _selectedProject = new Project();
        _projects = new ObservableCollection<Project>(projects.Cast<Project>());

        _selectedUser = new User();
        _users = new ObservableCollection<User>(users.Cast<User>());

        CreateTaskCommand = new RelayCommand.RelayCommand(o => CreateTask((Window)o));
        CloseWindowCommand = new RelayCommand.RelayCommand(o => CloseWindow((Window)o));
    }

    private void CreateTask(Window window)
    {
        if (Validate(NewTask.Title))
        {
            DialogResult = true;

            NewTask = new()
            {
                Title = NewTask.Title,
                ProjectId = SelectedProject.ProjectId,
                UserId = SelectedUser.UserId
            };

            MessageBox.Show("Task added");
            window?.Close();
        }
    }

    private void CloseWindow(Window window)
    {
        DialogResult = false;
        window?.Close();
    }

    private static bool Validate(string title)
    {
        if (title is null)
        {
            MessageBox.Show("Enter a valid data", "Error", MessageBoxButton.OK);
            return false;
        }

        return true;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
