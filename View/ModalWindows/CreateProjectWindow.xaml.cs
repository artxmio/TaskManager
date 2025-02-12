using System.Windows;
using TaskManager.ViewModel.CreateProjectViewModel;
namespace TaskManager.View.ModalWindows;

public partial class CreateProjectWindow : Window
{
    public CreateProjectWindow(CreateProjectViewModel viewModel)
    {
        InitializeComponent();

        DataContext = viewModel;
    }
}
