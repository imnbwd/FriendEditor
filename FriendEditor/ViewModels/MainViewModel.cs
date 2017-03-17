using FriendEditor.EventArgs;
using FriendEditor.Models;
using FriendEditor.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Linq;

namespace FriendEditor.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region Variables

        private ObservableCollection<Friend> _allFriends;
        private Friend _selectedFriend;

        #endregion Variables

        #region Constructors

        public MainViewModel(IDataProvider dataProvider, IEditWindowController editWindowController, IDialogService dialogService)
        {
            DataProvider = dataProvider;
            EditWindowController = editWindowController;
            DialogService = dialogService;

            AddFriendCommand = new RelayCommand(AddFriend);
            EditFriendCommand = new RelayCommand<Friend>(EditFriend, friend => SelectedFriend != null);
            DeleteFriendCommand = new RelayCommand<Friend>(DeleteFriend, friend => SelectedFriend != null);

            AllFriends = new ObservableCollection<Friend>(dataProvider.GetAllFriends().OfType<Friend>());
        }

        #endregion Constructors

        #region Properties

        public RelayCommand AddFriendCommand { get; set; }

        /// <summary>
        /// Get or set AllFriends value
        /// </summary>
        public ObservableCollection<Friend> AllFriends
        {
            get { return _allFriends; }
            set { Set(ref _allFriends, value); }
        }

        public IDataProvider DataProvider { get; }
        public RelayCommand<Friend> DeleteFriendCommand { get; set; }
        public IDialogService DialogService { get; }
        public RelayCommand<Friend> EditFriendCommand { get; set; }
        public IEditWindowController EditWindowController { get; }

        /// <summary>
        /// Get or set SelectedFriend value
        /// </summary>
        public Friend SelectedFriend
        {
            get { return _selectedFriend; }
            set
            {
                Set(ref _selectedFriend, value);

                // If SelectedFriend property changed, check if Edit&Delete commands can execute
                DeleteFriendCommand.RaiseCanExecuteChanged();
                EditFriendCommand.RaiseCanExecuteChanged();
            }
        }

        #endregion Properties

        #region Methods

        private void AddFriend()
        {
            var result = EditWindowController.ShowDialog(new OpenEditWindowArgs { Type = ActionType.Add });
            if (result.HasValue && result.Value)
            {
                AllFriends = new ObservableCollection<Friend>(DataProvider.GetAllFriends().OfType<Friend>());
            }
        }

        private void DeleteFriend(Friend friend)
        {
            if (DialogService.Confirm("Really want to delete this friend?"))
            {
                AllFriends.Remove(friend);
                DataProvider.Delete(friend);
                DialogService.ShowMessage("Delete friend successfully");
            }
        }

        private void EditFriend(Friend friend)
        {
            var result = EditWindowController.ShowDialog(new OpenEditWindowArgs { Type = ActionType.Edit, Friend = SelectedFriend });
            if (result.HasValue && result.Value)
            {
                // Remember user's selection
                int index = AllFriends.IndexOf(SelectedFriend);
                AllFriends = new ObservableCollection<Friend>(DataProvider.GetAllFriends().OfType<Friend>());

                // re-selected the original item
                SelectedFriend = AllFriends[index];
            }
        }

        #endregion Methods
    }
}