using System;
namespace Core.Core.UI
{
    public interface IBasePresenter<in V> where V : IBaseView
    {
        void SetView(V view);
        void OnBind();
        void OnUnbind();
        void SetUIScheduler(object scheduler);
    }
}
