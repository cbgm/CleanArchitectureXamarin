using System;
using Core.Presentation.Model;
using Foundation;
using UIKit;

namespace iOS.Feature.Start
{
    public partial class RepoCell : UITableViewCell
    {
        public static readonly NSString Key = new NSString("RepoCell");
        public static readonly UINib Nib;

        static RepoCell()
        {
            Nib = UINib.FromName("RepoCell", NSBundle.MainBundle);
        }

        public RepoCell()
        {

        }

        protected RepoCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public void UpdateCell(RepoOrganizationEntity repo)
        {
            lbl_repo_name.Text = repo.name;
            lbl_owner.Text = repo.owner.login;
            lbl_language.Text = repo.language;
            lbl_description.Text = repo.description;
        }
    }
}
