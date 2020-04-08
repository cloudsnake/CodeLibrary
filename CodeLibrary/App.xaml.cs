using Prism.Ioc;
using CodeLibrary.Views;
using System.Windows;

namespace CodeLibrary
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<CodeInfo>();
            containerRegistry.RegisterForNavigation<AddUpdateCodeDocument>();
        }
    }
}
