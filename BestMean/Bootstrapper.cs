using BestMean.ViewModels;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BestMean
{
    public class Bootstrapper: BootstrapperBase
    {
        public Bootstrapper()
        {
            /**start up some process*/
            Initialize();
        }
        /**we want that our application will run so we overrite onstartup method*/
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewForAsync<systemViewModel>();
        }
    }
}
