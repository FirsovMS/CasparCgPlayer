using CasparCgPlayer.UI.ViewModel;
using MahApps.Metro.Controls;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace CasparCgPlayer.UI.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private readonly MainViewModel _viewModel;

        public MainWindow(MainViewModel viewModel)
        {
            InitializeComponent();

            _viewModel = viewModel;
            DataContext = _viewModel;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _viewModel.Load();
        }
    }
}
