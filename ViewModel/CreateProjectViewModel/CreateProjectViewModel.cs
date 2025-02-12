using System.Windows;
using System.Windows.Input;
using TaskManager.Model.ProjectModel;

namespace TaskManager.ViewModel.CreateProjectViewModel;

public class CreateProjectViewModel
{
    public Project NewProject { get; set; }
    public bool DialogResult { get; set; }
    public ICommand CreateProjectCommand { get; set; }
    public ICommand CloseWindowCommand { get; set; }

    public CreateProjectViewModel()
    {
        NewProject = new Project();

        CreateProjectCommand = new RelayCommand.RelayCommand(o => CreateProject((Window)o));
        CloseWindowCommand = new RelayCommand.RelayCommand(o => CloseWindow((Window)o));
    }

    private void CreateProject(Window window)
    {
        if (Validate(NewProject.Title, NewProject.Description, NewProject.CountParticipants))
        {
            DialogResult = true;

            MessageBox.Show("A new project was added");
            window?.Close();
        }
    }

    private void CloseWindow(Window window)
    {
        DialogResult = false;
        window?.Close();
    }

    private bool Validate(string title, string description, int countPartisipants)
    {
        if ((title is null) || (description is null) || countPartisipants < 0)
        {
            MessageBox.Show("Enter a valid data", "Error", MessageBoxButton.OK);
            return false;
        }

        return true;
    }
}
