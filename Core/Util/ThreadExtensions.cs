﻿using System;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Threading;

namespace Core.Util
{
    public static class ThreadExtensions
    {

        public static IObservable<T> ObserveOnWith<T, S>(this IObservable<T> it, S scheduler)
        {
            if (scheduler is SynchronizationContext)
            {
                return it.ObserveOn(scheduler as SynchronizationContext);
            }
            else
            {
                return it.ObserveOn(scheduler as IScheduler);
            }
        }
    }
}
