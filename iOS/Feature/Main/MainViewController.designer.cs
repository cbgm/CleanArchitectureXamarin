// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace CleanArch.iOS
{
    [Register ("MainViewController")]
    partial class MainViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton btn_load { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView table_repos { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (btn_load != null) {
                btn_load.Dispose ();
                btn_load = null;
            }

            if (table_repos != null) {
                table_repos.Dispose ();
                table_repos = null;
            }
        }
    }
}