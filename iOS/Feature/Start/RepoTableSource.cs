using System;
using System.Collections.Generic;
using CleanArch.Droid.Model;
using Domain.Model;
using Foundation;
using UIKit;

namespace CleanArch.iOS.Feature.Main
{
    public class RepoTableSource : UITableViewSource
    {
        private List<RepoOrganizationEntity> Repos = new List<RepoOrganizationEntity>();
        private string CellIdentifier = "cell_repo";

        public RepoTableSource(List<RepoOrganizationEntity> items)
        {
            Repos.AddRange(items);
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(CellIdentifier, indexPath) as RepoCell;
            RepoOrganizationEntity item = Repos[indexPath.Row];

            if (cell == null)
            {
                cell = new RepoCell();
            }

            cell.UpdateCell(item);

            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section) => Repos.Count;
    }
}