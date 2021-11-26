using Autofac;
using CasparCgPlayer.UI.Handlers;
using CasparCgPlayer.UI.View;
using ControlzEx.Theming;
using Prism.Commands;
using System;
using System.Windows;
using System.Windows.Input;

namespace CasparCgPlayer.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public ICommand OpenSettingsWindow { get; set; }
        public ICommand SwitchThemeMode { get; set; }

        public MainViewModel(LanguageHandler languageHandler) 
            : base(languageHandler)
        {
            SwitchThemeMode = new DelegateCommand(OnSwitchThemeColor);
            OpenSettingsWindow = new DelegateCommand(OnOpenSettingsWindow);
        }

        private void OnOpenSettingsWindow()
        {
            // here we need to use abstract fabriq
            var settingsWindow = App.Container.Resolve<SettingsWindow>();
            settingsWindow.ShowDialog();
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
