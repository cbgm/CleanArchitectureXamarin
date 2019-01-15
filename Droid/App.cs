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
                   .As<IRepoOrganizationRepository>();

            builder.Register(c =>
                             new NetworkModule<ReposApi>().CreateWebService()).As<ReposApi>();

            builder.RegisterType<GetReposUseCase>()
                   .AsSelf();

            builder.RegisterType<MainPresenter>()
                    .AsSelf();

            Container = builder.Build();
        }

    }
}