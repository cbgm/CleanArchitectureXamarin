﻿using System;
using System.Collections.Generic;
using Core.Presentation.Model;
using Foundation;
using UIKit;

namespace iOS.Feature.Start
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