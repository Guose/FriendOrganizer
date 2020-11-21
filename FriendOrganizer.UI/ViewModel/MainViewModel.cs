using Autofac.Features.Indexed;
using FriendOrganizer.UI.Event;
using FriendOrganizer.UI.View.Services;
using Prism.Commands;
using Prism.Events;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FriendOrganizer.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private IMessageDialogService _messageDialogService;
        private IEventAggregator _eventAggregator;
        private IIndex<string, IDetailViewModel> _detailViewModelCreator;
        private IDetailViewModel _selectedDetailViewModel;

        public MainViewModel(INavigationViewModel navigationViewModel,
            IIndex<string, IDetailViewModel> detailViewModelCreator,
            IEventAggregator eventAggregator,
            IMessageDialogService messageDialogService)
        {
            _eventAggregator = eventAggregator;
            _detailViewModelCreator = detailViewModelCreator;
            _messageDialogService = messageDialogService;

            DetailViewModels = new ObservableCollection<IDetailViewModel>();

            _eventAggregator.GetEvent<OpenDetailViewEvent>()
                .Subscribe(OnOpenDetailView);
            _eventAggregator.GetEvent<AfterDetailDeletedEvent>()
                .Subscribe(AfterDetailDeleted);

            CreateNewDetailCommand = new DelegateCommand<Type>(OnCreateNewDetailExecute);

            NavigationViewModel = navigationViewModel;
        }

        public async Task LoadAsync()
        {
            await NavigationViewModel.LoadAsync();
        }

        public ICommand CreateNewDetailCommand { get; }

        public INavigationViewModel NavigationViewModel { get; }     
        
        public ObservableCollection<IDetailViewModel> DetailViewModels { get; }

        public IDetailViewModel SelectedDetailViewModel
        {
            get { return _selectedDetailViewModel; }
            set { _selectedDetailViewModel = value; OnPropertyChanged(); }
        }

        private async void OnOpenDetailView(OpenDetailViewEventArgs args)
        {
            var detailViewModel = DetailViewModels
                .SingleOrDefault(vm => vm.Id == args.Id 
                && vm.GetType().Name == args.ViewModelName);

            if (detailViewModel == null)
            {
                detailViewModel = _detailViewModelCreator[args.ViewModelName];
                await detailViewModel.LoadAsync(args.Id);
                DetailViewModels.Add(detailViewModel);
            }

            SelectedDetailViewModel = detailViewModel;            
        }

        private void OnCreateNewDetailExecute(Type viewModelType)
        {
            OnOpenDetailView(
                new OpenDetailViewEventArgs { ViewModelName = viewModelType.Name });
        }

        private void AfterDetailDeleted(AfterDetailDeletedEventArgs args)
        {
            var detailViewModel = DetailViewModels
                .SingleOrDefault(vm => vm.Id == args.Id
                && vm.GetType().Name == args.ViewModelName);

            if (detailViewModel != null)
            {
                DetailViewModels.Remove(detailViewModel);
            }
        }
    }
}
