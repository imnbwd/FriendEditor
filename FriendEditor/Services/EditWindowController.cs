using FriendEditor.EventArgs;
using FriendEditor.Views;
using GalaSoft.MvvmLight.Ioc;

namespace FriendEditor.Services
{
    public class EditWindowController : IEditWindowController
    {
        /// <summary>
        /// Show EditWindow
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public bool? ShowDialog(OpenEditWindowArgs args)
        {
            // If the container contains then target Type, then remove it firstly, or else an Exception will be thrown here
            if (SimpleIoc.Default.ContainsCreated<OpenEditWindowArgs>())
            {
                SimpleIoc.Default.Unregister<OpenEditWindowArgs>();
            }

            SimpleIoc.Default.Register(() => args);

            EditWindow editWindow = new EditWindow();
            return editWindow.ShowDialog();
        }
    }
}