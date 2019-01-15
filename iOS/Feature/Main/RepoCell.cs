using System;

using Foundation;
using UIKit;

namespace CleanArch.iOS.Feature.Main
{
    public partial class RepoCell : UITableViewCell
    {
        public static readonly NSString Key = new NSString("RepoCell");
        public static readonly UINib Nib;

        static RepoCell()
        {
            Nib = UINib.FromName("RepoCell", NSBundle.MainBundle);
        }

        protected RepoCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }
    }
}
