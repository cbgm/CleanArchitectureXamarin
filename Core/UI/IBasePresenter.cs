using System;
using System.Reactive.Concurrency;
using System.Threading;

namespace Core.UI
{
    public interface IBasePresenter<in V, S> where V : IBaseView
    {
        void SetView(V view);
        void OnBind();
        void OnUnbind();
        void SetUIScheduler(S scheduler);
    }
}
