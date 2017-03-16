using System;

namespace FriendEditor.Models
{
    public interface IFriend
    {
        DateTime BirthDate { get; set; }
        string Email { get; set; }
        string Id { get; set; }
        bool IsDeveloper { get; set; }

        string Name { get; set; }
    }
}