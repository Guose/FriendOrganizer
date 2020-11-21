using FriendOrganizer.UI.Event;
using Prism.Commands;
using Prism.Events;
using System;
using System.Windows.Input;

namespace FriendOrganizer.UI.ViewModel
{
    public class NavigationItemViewModel : ViewModelBase
    {
        private string _displayMemeber;
        private IEventAggregator _eventAggregator;
        private string _detailViewModelName;

        public NavigationItemViewModel(int id, string displayMember,
            string detailViewModelName,
            IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            Id = id;
            DisplayMember = displayMember;
            _detailViewModelName = detailViewModelName;
            OpenDetailViewCommand = new DelegateCommand(OnOpenDetailViewExecute);
        }

        public int Id { get; }

        public string DisplayMember
        {
            get { return _displayMemeber; }
            set { _displayMemeber = value; OnPropertyChanged(); }
        }       

        public ICommand OpenDetailViewCommand { get; set; }

        private void OnOpenDetailViewExecute()
        {
            //When a friend is selected it raises the OpenFriendDetailViewEvent handler
            _eventAggregator.GetEvent<OpenDetailViewEvent>()
                .Publish(
                new OpenDetailViewEventArgs
                {
                    Id = Id,
                    ViewModelName = _detailViewModelName
                });
        }
    }
}