using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;
using Autofac;
using System;
using System.Collections.Generic;
using Core.Presentation.Feature.Start;
using Core.Presentation.Model;
using Core.Core.DI;

namespace Droid.Feature.Start
{
    [Activity(Label = "CleanArch", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity, IStartView
    {
        MainPresenter presenter;// = new MainPresenter();
        RecyclerView RvRepos;
        ReposAdapter Adapter;
        Button button;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            InitViews();

            using (var scope = Injector.Instance.InjectableContainer.BeginLifetimeScope())
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