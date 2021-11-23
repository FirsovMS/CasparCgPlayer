using Autofac;
using CasparCgPlayer.UI.Startup;
using CasparCgPlayer.UI.View;
using System;
using System.Windows;

namespace CasparCgPlayer.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IContainer _container;
        private readonly LogHelper _logger;

        public App()
        {
            var bootrstrapper = new Bootstrapper();
            _container = bootrstrapper.Bootstrap();

            // yeah, it's a bad usage of service locator here, propably should use 'safe-access' decorator here
            _logger = _container.Resolve<LogHelper>();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            try
            {
                var mainWindow = _container.Resolve<MainWindow>();
                mainWindow.Show();
            }
            catch (Exception ex)
            {
                _logger.Error(description: "MainWindow not created!", exception: ex, logLevel: NLog.LogLevel.Error);

                MessageBox.Show("Application not created! See log file for more information", "Startup Error");

                Current.Shutdown();
            }
        }

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            _logger.Error(description: "Unexpected Error occured", exception: e.Exception, logLevel: NLog.LogLevel.Fatal);

            MessageBox.Show("Unexpected Error occured. See the log inforamtion.", "Unexpected error");

            e.Handled = true;
        }
    }
}
