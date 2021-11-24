using ControlzEx.Theming;
using Prism.Commands;
using System.Windows;
using System.Windows.Input;

namespace CasparCgPlayer.UI.ViewModel
{
    public class MainViewModel
    {
        public ICommand SwitchThemeMode { get; set; }

        public MainViewModel()
        {
            SwitchThemeMode = new DelegateCommand(OnSwitchThemeColor);
        }

        private void OnSwitchThemeColor()
        {
            var currentThemeManager = ThemeManager.Current;

            var currentTheme = currentThemeManager.DetectTheme();
            var inverseTheme = currentThemeManager.GetInverseTheme(currentTheme);

            currentThemeManager.ChangeTheme(Application.Current, inverseTheme);
        }

        public void Load()
        {

        }
    }
}
