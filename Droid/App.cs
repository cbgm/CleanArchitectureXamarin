using System;
using System.Collections.Generic;
using Android.App;
using Core.Core.DI;

namespace Droid
{
    [Application]
    public class App : Application
    {
        public App(IntPtr javaReference, Android.Runtime.JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();
            Injector.Instance.Init(new List<IComponent> { new CoreComponents(), new StartComponents() });
        }
    }
}