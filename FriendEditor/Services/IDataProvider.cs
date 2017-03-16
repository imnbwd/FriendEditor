using FriendEditor.Models;
using System.Collections.Generic;

namespace FriendEditor.Services
{
    public interface IDataProvider
    {
        bool Delete(IFriend friend);

        List<IFriend> GetAllFriends();

        IFriend GetFriendById(string id);

        bool Insert(IFriend friend);

        bool Update(IFriend friend);
    }
}