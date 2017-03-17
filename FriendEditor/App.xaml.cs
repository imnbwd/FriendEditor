using FriendEditor.Services;
using FriendEditor.Views;
using GalaSoft.MvvmLight.Ioc;
using System.Windows;

namespace FriendEditor
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            SimpleIoc.Default.Register<IDataProvider, SqliteDataProvider>();
            SimpleIoc.Default.Register<IEditWindowController, EditWindowController>();
            SimpleIoc.Default.Register<IDialogService, DialogService>();

            App.Current.DispatcherUnhandledException += (s, args) =>
            {
                SimpleIoc.Default.GetInstance<IDialogService>().Exception(args.Exception);
                args.Handled = true;
            };

            MainWindow mainWindow = new MainWindow();
            App.Current.MainWindow = mainWindow;
            mainWindow.Show();
        }
    }
}