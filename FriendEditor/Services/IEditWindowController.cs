using FriendEditor.EventArgs;

namespace FriendEditor.Services
{
    public interface IEditWindowController
    {
        bool? ShowDialog(OpenEditWindowArgs args);
    }
}