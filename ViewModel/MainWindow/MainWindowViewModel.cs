using System.Collections.ObjectModel;
using TaskManager.Model.ProjectModel;

namespace TaskManager.ViewModel.MainWindow;

public class MainWindowViewModel : IMainWindowViewModel
{
    public ObservableCollection<IProject> Data { get; set; }
}
