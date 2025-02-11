using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using TaskManager.Model.ProjectModel;
using TaskManager.ViewModel.RelayCommand;

namespace TaskManager.ViewModel.MainWindow;

public class MainWindowViewModel : IMainWindowViewModel
{
    public ObservableCollection<Project> Data { get; set; }

    public ICommand CloseCommand { get; set; }

    public MainWindowViewModel()
    {
        Data = new ObservableCollection<Project>();

        CloseCommand = new RelayCommand.RelayCommand(o => CloseWindow((Window)o));
    }

    private void CloseWindow(Window window)
    {
        window?.Close();
    }
}
