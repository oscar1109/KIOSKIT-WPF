using Caliburn.Micro;
using System.Windows;
using WindowExplorer.ViewModels;

namespace WindowExplorer
{
    public class Wrapper : BootstrapperBase
    {
        public Wrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<WindowExplorerViewModel>();
        }
    }
}
