using Autofac;
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

            container.RegisterType<LogHelper>().AsSelf().SingleInstance();

            container.RegisterType<MainWindow>().AsSelf();
            container.RegisterType<MainViewModel>().AsSelf();

            return container.Build();
        }
    }
}
