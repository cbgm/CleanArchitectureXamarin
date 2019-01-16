// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace iOS.Feature.Start
{
    [Register ("RepoCell")]
    partial class RepoCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lbl_description { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lbl_language { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lbl_owner { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lbl_repo_name { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (lbl_description != null) {
                lbl_description.Dispose ();
                lbl_description = null;
            }

            if (lbl_language != null) {
                lbl_language.Dispose ();
                lbl_language = null;
            }

            if (lbl_owner != null) {
                lbl_owner.Dispose ();
                lbl_owner = null;
            }

            if (lbl_repo_name != null) {
                lbl_repo_name.Dispose ();
                lbl_repo_name = null;
            }
        }
    }
}