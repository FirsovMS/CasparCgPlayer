using Autofac;
using CasparCgPlayer.UI.Handlers;
using CasparCgPlayer.UI.View;
using CasparCgPlayer.UI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasparCgPlayer.UI.Startup
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var container = new ContainerBuilder();

            container.RegisterType<LogHandler>().AsSelf().SingleInstance();
            container.RegisterType<LanguageHandler>().AsSelf().SingleInstance();

            container.RegisterType<SettingsViewModel>().AsSelf();
            container.RegisterType<SettingsWindow>().AsSelf();

            container.RegisterType<MainViewModel>().AsSelf();
            container.RegisterType<MainWindow>().AsSelf();

            return container.Build();
        }
    }
}
