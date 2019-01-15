using System;
using Android.App;
using Autofac;
using Data.Api;
using Data.Repository;
using Data.Repository.DataSource;
using Domain.UseCase;
using Domain.Repository;
using Core.DI;
using Presentation;
using System.Reactive.Concurrency;
using System.Threading;

namespace CleanArch.Droid
{
    [Application]
    public class App : Application
    {
        public static IContainer Container { get; set; }

        public App(IntPtr javaReference, Android.Runtime.JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();

            var builder = new ContainerBuilder();

            builder.RegisterType<RepositoryDataSource>()
                   .As<IDataSource>();

            builder.RegisterType<RepositoryImpl>()
                   .As<IRepository>();

            /*builder.RegisterType<AppHttpClientHandler>()
                   .AsSelf();

            builder.Register(c =>
                             new ApiFactory<ReposApi>(
                                 c.Resolve<AppHttpClientHandler>()).Create())
                   .As<ReposApi>();*/

            builder.Register(c =>
                             new NetworkModule<ReposApi>().CreateWebService()).As<ReposApi>();

            builder.RegisterType<GetReposUseCase<IScheduler>>()
                   .AsSelf();

            builder.RegisterType<GetReposUseCase<SynchronizationContext>>()
                  .AsSelf();

            builder.RegisterType<MainPresenter<IScheduler>>()
                    .AsSelf();

            builder.RegisterType<MainPresenter<SynchronizationContext>>()
                    .AsSelf();

            Container = builder.Build();
        }

    }
}