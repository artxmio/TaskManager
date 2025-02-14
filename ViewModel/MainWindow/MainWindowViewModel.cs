using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using TaskManager.Model.ProjectModel;
using TaskManager.View.ModalWindows;

namespace TaskManager.ViewModel.MainWindow;

public class MainWindowViewModel : IMainWindowViewModel, INotifyPropertyChanged
{
    private readonly ApplicationContext.ApplicationContext _context = new ApplicationContext.ApplicationContext();
    private bool _isProjectChanged;

    public event PropertyChangedEventHandler? PropertyChanged;

    public ObservableCollection<Project> Data { get; set; }
    public Project? SelectedProject { get; set; }
    public bool IsProjectChanged
    {
        get => _isProjectChanged;
        set
        {
            if (_isProjectChanged != value)
            {
                _isProjectChanged = value;
                OnPropertyChanged();
            }
        }
    }

    public ICommand CloseCommand { get; set; }
    public ICommand CreateProjectCommand { get; set; }
    public ICommand DeleteProjectCommand { get; set; }
    public ICommand SaveChangesCommand { get; set; }

    public MainWindowViewModel()
    {
        Data = new ObservableCollection<Project>();
        IsProjectChanged = false;

        CloseCommand = new RelayCommand.RelayCommand(o => CloseWindow((Window)o));
        CreateProjectCommand = new RelayCommand.RelayCommand(o => CreateProject());
        DeleteProjectCommand = new RelayCommand.RelayCommand(o => DeleteProject());
        SaveChangesCommand = new RelayCommand.RelayCommand(o => SaveProjectChanges());

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
            IsProjectChanged = true;
        }
    }

    private void DeleteProject()
    {
        if (SelectedProject is not null)
        {
            _context.Projects.Remove(SelectedProject);
            IsProjectChanged = true;
        }
        else
        {
            MessageBox.Show("Please, select a project", "Error", MessageBoxButton.OK);
        }
    }

    private void SaveProjectChanges()
    {
        _context.SaveChanges();
        IsProjectChanged = false;
        MessageBox.Show("Changes was saved", "Success", MessageBoxButton.OK);
    }

    private void CloseWindow(Window window)
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
