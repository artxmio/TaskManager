using System.Windows;
using TaskManager.ViewModel.UpdateProjectViewModel;

namespace TaskManager.View.ModalWindows;

public partial class UpdateProjectWindow : Window
{
    public UpdateProjectWindow(UpdateProjectViewModel viewModel)
    {
        InitializeComponent();

        DataContext = viewModel;
    }
}
