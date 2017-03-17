using FriendEditor.EventArgs;

namespace FriendEditor.Services
{
    public interface IEditWindowController
    {
        /// <summary>
        /// Show EditWindow
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        bool? ShowDialog(OpenEditWindowArgs args);
    }
}