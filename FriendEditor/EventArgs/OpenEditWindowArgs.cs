using FriendEditor.Models;

namespace FriendEditor.EventArgs
{
    /// <summary>
    /// Action Type
    /// </summary>
    public enum ActionType
    {
        /// <summary>
        /// Add a friend
        /// </summary>
        Add,

        /// <summary>
        /// Edit a friend
        /// </summary>
        Edit
    }

    /// <summary>
    /// Open EditWindow arguments
    /// </summary>
    public class OpenEditWindowArgs
    {
        /// <summary>
        /// If <see cref="ActionType"/> is Edit, then the value for this property need to be provided
        /// </summary>
        public Friend Friend { get; set; }

        public ActionType Type { get; set; }
    }
}