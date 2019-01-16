using Foundation;
using UIKit;
using Core.Core.DI;
using System.Collections.Generic;

namespace IOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        public override UIWindow Window
        {
            get;
            set;
        }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            Injector.Instance.Init(new List<IComponent> { new CoreComponents(), new StartComponents() });
            return true;
        }
    }
}

