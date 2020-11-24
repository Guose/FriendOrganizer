using Autofac;
using Prism.Events;
using FriendOrganizer.DataAccess;
using FriendOrganizer.UI.Data.Repositories;
using FriendOrganizer.UI.ViewModel;
using FriendOrganizer.UI.Data.Lookups;
using FriendOrganizer.UI.View.Services;

namespace FriendOrganizer.UI.Startup
{
    //Injector class injects the service class into the client class
    public class Bootstrapper
    {
        //namespace Autofac is used for dependency injection
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            //this has been injected into a Func method in the FriendDataService class
            builder.RegisterType<FriendOrganizerDbContext>().AsSelf();

            //Whenever the IEventAggregator is required somewhere, the ContainerBuilder method will create and instance
            //of the EventAggregator class object
            builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();

            //AsSelf just created instance of what's being registered
            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MessageDialogService>().As<IMessageDialogService>();
            builder.RegisterType<MainViewModel>().AsSelf();
            builder.RegisterType<NavigationViewModel>().As<INavigationViewModel>();
            builder.RegisterType<FriendDetailViewModel>()
                .Keyed<IDetailViewModel>(nameof(FriendDetailViewModel));
            builder.RegisterType<MeetingDetailViewModel>()
                .Keyed<IDetailViewModel>(nameof(MeetingDetailViewModel));
            builder.RegisterType<ProgrammingLanguageDetailViewModel>()
                .Keyed<IDetailViewModel>(nameof(ProgrammingLanguageDetailViewModel));


            //AsImplemetedInterfaces method, so you can implement multiple interfaces that is inherited by LookUpDataService
            builder.RegisterType<LookUpDataSerivce>().AsImplementedInterfaces();
            builder.RegisterType<FriendRepository>().As<IFriendRepository>();
            builder.RegisterType<MeetingRepository>().As<IMeetingRepository>();
            builder.RegisterType<ProgrammingLanguageRepository>().As<IProgrammingLanguageRepository>();

            return builder.Build();
        }
    }
}
