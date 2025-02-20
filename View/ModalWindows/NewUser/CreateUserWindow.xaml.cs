using System.Windows;
using TaskManager.ViewModel.CreateUserViewModel;
namespace TaskManager.View.ModalWindows.NewUser;

public partial class CreateUserWindow : Window
{
    public CreateUserWindow(CreateUserViewModel viewModel)
    {
        InitializeComponent();

        DataContext = viewModel;
    }
}
