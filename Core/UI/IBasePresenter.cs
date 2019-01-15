using System;
namespace Core.UI
{
    public interface IBasePresenter<in V> where V: IBaseView
    {
        void SetView(V view);
        void OnBind();
        void OnUnbind();
    }
}
