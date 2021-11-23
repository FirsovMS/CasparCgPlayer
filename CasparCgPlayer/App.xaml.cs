using Autofac;
using CasparCgPlayer.UI.Startup;
using CasparCgPlayer.UI.View;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CasparCgPlayer.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IContainer _container;

        public App()
        {
            var bootrstrapper = new Bootstrapper();
            _container = bootrstrapper.Bootstrap();
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
                Logger.Error(description: "MainWindow not created!", exception: ex, logLevel: Level.Fatal);
                MessageBox.Show("Application not created! See log file for more information", "Startup Error");
                Current.Shutdown();
            }
        }

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {

        }
    }
}
