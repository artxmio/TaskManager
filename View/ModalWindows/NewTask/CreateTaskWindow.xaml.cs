using System.Windows;
using TaskManager.ViewModel.CreateTaskViewModel;

namespace TaskManager.View.ModalWindows.NewTask;

public partial class CreateTaskWindow : Window
{
    public CreateTaskWindow(CreateTaskViewModel viewModel)
    {
        InitializeComponent();

        DataContext = viewModel;
    }
}
