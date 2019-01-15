using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using Domain.UseCase;
using Autofac;
using System;
//using System.Reactive.Linq;
//using System.Reactive.Concurrency;
using System.Threading.Tasks;
using Java.Lang;
using Presentation;
using CleanArch.Droid.Model;
using System.Collections.Generic;
using System.Threading;

namespace CleanArch.Droid.Feature.Start
{
    [Activity(Label = "CleanArch", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity, IStartView
    {
        MainPresenter presenter;
        RecyclerView RvRepos;
        ReposAdapter Adapter;
        Button button;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.main_activity);
            InitViews();

            using (var scope = App.Container.BeginLifetimeScope())
            {
                presenter = scope.Resolve<MainPresenter>();
            }

            presenter.SetUIScheduler(Application.SynchronizationContext);
            presenter.SetView(this);

        }

        void InitViews()
        {
            RvRepos = FindViewById<RecyclerView>(Resource.Id.rvRepos);
            Adapter = new ReposAdapter();
            RvRepos.SetAdapter(Adapter);
            RvRepos.SetLayoutManager(new LinearLayoutManager(this));



            button = FindViewById<Button>(Resource.Id.btnLoad);
            button.Click += delegate
            {
                presenter.LoadRepo("jetruby");
            };
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            presenter.OnUnbind();
        }

        public void ShowRepo(List<RepoOrganizationEntity> repos)
        {
            Adapter.addItems(repos);
        }

        public void ShowError(bool isVisible)
        {
            throw new NotImplementedException();
        }

        public void ShowLoading(bool isVisible)
        {
            throw new NotImplementedException();
        }

        public void ShowContent(bool isVisible)
        {
            throw new NotImplementedException();
        }
    }
}