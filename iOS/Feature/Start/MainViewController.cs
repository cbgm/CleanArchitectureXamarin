using System;
using Autofac;
using UIKit;
using ReactiveUI;
using System.Collections.Generic;
using Core.Presentation.Feature.Start;
using Core.Presentation.Model;
using Core.Core.DI;

namespace iOS.Feature.Start
{
    public partial class MainViewController : UIViewController, IStartView
    {
        MainPresenter presenter;

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

            using (var scope = Injector.Instance.InjectableContainer.BeginLifetimeScope())
            {
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
                presenter.LoadRepo("jetruby");
            };
        }
    }
}
