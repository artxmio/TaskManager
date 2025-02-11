using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using TaskManager.Model.ProjectModel;

namespace TaskManager.ViewModel.MainWindow;

public class MainWindowViewModel : IMainWindowViewModel
{
    private ApplicationContext.ApplicationContext _context = new ApplicationContext.ApplicationContext();

    public ObservableCollection<Project> Data { get; set; }

    public ICommand CloseCommand { get; set; }

    public MainWindowViewModel()
    {
        Data = new ObservableCollection<Project>();
        
        CloseCommand = new RelayCommand.RelayCommand(o => CloseWindow((Window)o));

        if (_context is not null)
        {
            _context.Projects.Load();
            Data = _context.Projects.Local.ToObservableCollection();
        }
    }

    private void CreateProject()
    {
    }

    private void CloseWindow(Window window)
    {
        window?.Close();
    }
}
