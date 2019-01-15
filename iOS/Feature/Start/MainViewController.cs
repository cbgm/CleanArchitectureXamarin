using System;
using Autofac;
using Domain.UseCase;
using UIKit;
using Foundation;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Threading.Tasks;
using ReactiveUI;
using Presentation;
using CleanArch.Droid.Feature.Start;
using CleanArch.Droid.Model;
using System.Collections.Generic;

namespace CleanArch.iOS.Feature.Main
{
    public partial class MainViewController : UIViewController, IStartView
    {
        MainPresenter presenter;
        //IDisposable Disposable;
        //GetReposUseCase reposUseCase;

        public MainViewController(IntPtr handle) : base(handle)
        {
        }

        public void ShowContent(bool isVisible)
        {
            throw new NotImplementedException();
        }

        public void ShowError(bool isVisible)
        {
            throw new NotImplementedException();
        }

        public void ShowLoading(bool isVisible)
        {
            throw new NotImplementedException();
        }

        public void ShowRepo(List<RepoOrganizationEntity> repos)
        {
            table_repos.Source = new RepoTableSource(repos);
            table_repos.ReloadData();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            using (var scope = AppDelegate.Container.BeginLifetimeScope())
            {
                //reposUseCase = scope.Resolve<GetReposUseCase>();
                presenter = scope.Resolve<MainPresenter>();
            }
            presenter.SetUIScheduler(new NSRunloopScheduler());
            presenter.SetView(this);
            table_repos.RegisterNibForCellReuse(RepoCell.Nib, "cell_repo");
            table_repos.RowHeight = UITableView.AutomaticDimension;
            table_repos.EstimatedRowHeight = 40f;
            table_repos.ReloadData();

            btn_load.TouchUpInside += delegate
            {
                /*Disposable = reposUseCase
                    .Get("jetruby")
                    .SubscribeOn(ThreadPoolScheduler.Instance)
                    .ObserveOn(new NSRunloopScheduler())
                    .Subscribe(
                        list =>
                        {
                            table_repos.Source = new RepoTableSource(list);
                            table_repos.ReloadData();
                        },
                        error => { },
                        () => { }
                    );*/
                presenter.LoadRepo("jetruby");
            };
        }
    }
}
