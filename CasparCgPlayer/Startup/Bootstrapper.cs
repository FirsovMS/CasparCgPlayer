using Autofac;
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


            return container.Build();
        }
    }
}
