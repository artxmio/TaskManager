using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using TaskManager.Model.ProjectModel;

namespace TaskManager.ViewModel.MainWindow;

public class MainWindowViewModel : IMainWindowViewModel
{
    public ObservableCollection<Project> Data { get; set; }

    public ICommand CloseCommand { get; set; }

    public MainWindowViewModel()
    {
        Data = new ObservableCollection<Project>();

        Data.Add(new Project("Название1", "Описание1", 1, false));
        Data.Add(new Project("Название2", "Описание2", 2, true));
        Data.Add(new Project("Название3", "Описание3", 3, false));

        CloseCommand = new RelayCommand.RelayCommand(o => CloseWindow((Window)o));
    }

    private void CloseWindow(Window window)
    {
        window?.Close();
    }
}
