using System.Windows.Input;
using System.Windows;
using TaskManager.Model.ProjectModel;
using TaskManager.Model.UserModel;

namespace TaskManager.ViewModel.CreateUserViewModel;

public class CreateUserViewModel
{
    public User NewUser { get; set; }
    public bool DialogResult { get; set; }
    public ICommand CreateUserCommand { get; set; }
    public ICommand CloseWindowCommand { get; set; }

    public CreateUserViewModel()
    {
        NewUser = new User();

        CreateUserCommand = new RelayCommand.RelayCommand(o => CreateUser((Window)o));
        CloseWindowCommand = new RelayCommand.RelayCommand(o => CloseWindow((Window)o));
    }

    private void CreateUser(Window window)
    {
        if (Validate(NewUser.Login, NewUser.Password))
        {
            DialogResult = true;

            MessageBox.Show("User added");
            window?.Close();
        }
    }

    private void CloseWindow(Window window)
    {
        DialogResult = false;
        window?.Close();
    }

    private static bool Validate(string login, string password)
    {
        if ((login is null) || (password is null))
        {
            MessageBox.Show("Enter a valid data", "Error", MessageBoxButton.OK);
            return false;
        }

        return true;
    }
}
