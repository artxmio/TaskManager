using System.Windows;
using System.Windows.Input;
using TaskManager.Model.ProjectModel;

namespace TaskManager.ViewModel.UpdateProjectViewModel;

public class UpdateProjectViewModel
{
    public Project UpdatedProject { get; set; }
    public bool DialogResult { get; set; }
    public ICommand UpdateProjectCommand { get; set; }
    public ICommand CloseWindowCommand { get; set; }

    public UpdateProjectViewModel(Project updatableProject)
    {
        UpdatedProject = new Project();
        UpdatedProject.Title = updatableProject.Title;
        UpdatedProject.Description = updatableProject.Description;
        UpdatedProject.CountParticipants = updatableProject.CountParticipants;

        UpdateProjectCommand = new RelayCommand.RelayCommand(o => UpdateProject((Window)o));
        CloseWindowCommand = new RelayCommand.RelayCommand(o => CloseWindow((Window)o));
    }

    private void UpdateProject(Window window)
    {
        if (Validate(UpdatedProject.Title, UpdatedProject.Description, UpdatedProject.CountParticipants))
        {
            DialogResult = true;

            MessageBox.Show("Project updated");
            window?.Close();
        }
    }

    private void CloseWindow(Window window)
    {
        DialogResult = false;
        window?.Close();
    }

    private static bool Validate(string title, string description, int countPartisipants)
    {
        if ((title is null) || (description is null) || countPartisipants < 0)
        {
            MessageBox.Show("Enter a valid data", "Error", MessageBoxButton.OK);
            return false;
        }

        return true;
    }
}
