using Foundation;
using UIKit;
using Core.DI;
using Data.Api;
using Domain.UseCase;
using Domain.Repository;
using Data.Repository;
using Data.Repository.DataSource;
using Autofac;
using Presentation;
using ReactiveUI;

namespace CleanArch.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        // class-level declarations
        public static IContainer Container { get; set; }

        public override UIWindow Window
        {
            get;
            set;
        }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {

            var builder = new ContainerBuilder();

            builder.RegisterType<RepositoryDataSource>()
                   .As<IDataSource>();

            builder.RegisterType<RepositoryImpl>()
                   .As<IRepository>();
              
            builder.Register(c => new NetworkModule<ReposApi>().CreateWebService()).As<ReposApi>();

            builder.RegisterType<GetReposUseCase>()
                   .AsSelf();

            builder.RegisterType<MainPresenter>()
                   .AsSelf();

            Container = builder.Build();

            return true;
        }
    }
}

