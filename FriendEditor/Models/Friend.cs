using GalaSoft.MvvmLight;
using System;

namespace FriendEditor.Models
{
    public class Friend : ObservableObject, IFriend
    {
        private DateTime _birthDate;
        private string _email;
        private string _id;
        private bool _isDeveloper;
        private string _name;

        /// <summary>
        /// Get or set BirthDate value
        /// </summary>
        public DateTime BirthDate
        {
            get { return _birthDate; }
            set { Set(ref _birthDate, value); }
        }

        /// <summary>
        /// Get or set Email value
        /// </summary>
        public string Email
        {
            get { return _email; }
            set { Set(ref _email, value); }
        }

        /// <summary>
        /// Get or set Id value
        /// </summary>
        public string Id
        {
            get { return _id; }
            set { Set(ref _id, value); }
        }

        /// <summary>
        /// Get or set IsDeveloper value
        /// </summary>
        public bool IsDeveloper
        {
            get { return _isDeveloper; }
            set { Set(ref _isDeveloper, value); }
        }

        /// <summary>
        /// Get or set Name value
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { Set(ref _name, value); }
        }
    }
}