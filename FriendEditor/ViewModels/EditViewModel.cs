using FriendEditor.EventArgs;
using FriendEditor.Models;
using FriendEditor.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;

namespace FriendEditor.ViewModels
{
    public class EditViewModel : ViewModelBase
    {
        #region Constructors

        public EditViewModel(OpenEditWindowArgs args, IDataProvider dataProvider, IDialogService dialogService)
        {
            Args = args;
            DataProvider = dataProvider;
            DialogService = dialogService;

            switch (args.Type)
            {
                case ActionType.Add:
                    CurrentFriend = new Friend { Id = Guid.NewGuid().ToString(), BirthDate = new DateTime(1990, 1, 1) };
                    break;

                case ActionType.Edit:
                    // Clone a new object
                    CurrentFriend = new Friend
                    {
                        Id = args.Friend.Id,
                        Name = args.Friend.Name,
                        BirthDate = args.Friend.BirthDate,
                        Email = args.Friend.Email,
                        IsDeveloper = args.Friend.IsDeveloper
                    };
                    break;
            }

            SaveDataCommand = new RelayCommand(SaveData);
        }

        #endregion Constructors

        #region Properties

        public Friend CurrentFriend { get; set; }
        public IDataProvider DataProvider { get; }
        public IDialogService DialogService { get; set; }
        public RelayCommand SaveDataCommand { get; set; }
        protected OpenEditWindowArgs Args { get; }

        #endregion Properties

        #region Methods

        private void SaveData()
        {
            if (string.IsNullOrWhiteSpace(CurrentFriend.Name))
            {
                DialogService.Warning("Name is required");
                return;
            }

            bool result = false;
            switch (Args.Type)
            {
                case ActionType.Add:
                    result = DataProvider.Insert(CurrentFriend);

                    break;

                case ActionType.Edit:
                    result = DataProvider.Update(CurrentFriend);
                    break;
            }

            if (result)
            {
                DialogService.ShowMessage($"{Args.Type} friend successfully");

                // Send a message to Close the current View(EditWindow)
                Messenger.Default.Send(new CloseWindowEventArgs());
            }
            else
            {
                DialogService.Warning($"Error occured, save data failed");
            }
        }

        #endregion Methods
    }
}