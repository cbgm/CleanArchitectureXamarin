using System;
using Autofac;
using Domain.UseCase;
using UIKit;
using Foundation;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Threading.Tasks;
using ReactiveUI;

using CleanArch.iOS.Feature;

namespace CleanArch.iOS
{
    public partial class MainViewController : UIViewController
    {
        IDisposable Disposable;
        GetReposUseCase reposUseCase;

        public MainViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            using (var scope = AppDelegate.Container.BeginLifetimeScope())
            {
                reposUseCase = scope.Resolve<GetReposUseCase>();
            }

            table_repos.RegisterNibForCellReuse(RepoCell.Nib, "cell_repo");
            table_repos.RowHeight = UITableView.AutomaticDimension;
            table_repos.EstimatedRowHeight = 40f;
            table_repos.ReloadData();

            btn_load.TouchUpInside += delegate
            {
                Disposable = reposUseCase
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
                    );
            };
        }
    }
}
