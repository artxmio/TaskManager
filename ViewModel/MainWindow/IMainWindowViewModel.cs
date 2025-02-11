using System.Collections.ObjectModel;
using TaskManager.Model.ProjectModel;

namespace TaskManager.ViewModel.MainWindow;

public interface IMainWindowViewModel
{
    ObservableCollection<IProject> Data { get; set; }
}