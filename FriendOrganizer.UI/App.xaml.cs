using Autofac;
using FriendOrganizer.UI.Startup;
using System;
using System.Windows;

namespace FriendOrganizer.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var bootstrapper = new Bootstrapper();
            var container = bootstrapper.Bootstrap();

            //The Resolve method will go to MainWindow contructor and see that it needs to create a MainViewModel, and then it'll go to
            //the MainViewModel constructor and see that it needs to create an IFriendDataService at which bootstrapper has FriendDataService
            //as a RegisteredType of IFriendDataService and calls methods for the Window_Loaded event of the MainWindow
            var mainWindow = container.Resolve<MainWindow>();
            mainWindow.Show();
        }

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("Unexpected error occured. Please inform the admin.\n"
                + Environment.NewLine + e.Exception.Message, "Unexpected Error", MessageBoxButton.OK, MessageBoxImage.Error);

            e.Handled = true;
        }
    }
}
