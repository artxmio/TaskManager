using System.Windows;
using TaskManager.ViewModel.MainWindow;

namespace TaskManager.View
{
    public partial class MainWindow : Window
    {
        private readonly IMainWindowViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();

            _viewModel = new MainWindowViewModel();

            this.DataContext = _viewModel;
        }
    }
}
