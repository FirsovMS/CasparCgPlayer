using CasparCgPlayer.UI.ViewModel;
using MahApps.Metro.Controls;

namespace CasparCgPlayer.UI.View
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : MetroWindow
    {
        private readonly SettingsViewModel _settingsViewModel;

        public SettingsWindow(SettingsViewModel settingsViewModel)
        {
            InitializeComponent();

            _settingsViewModel = settingsViewModel;
            DataContext = _settingsViewModel;
        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _settingsViewModel.OnSettingsClosing();
        }
    }
}
