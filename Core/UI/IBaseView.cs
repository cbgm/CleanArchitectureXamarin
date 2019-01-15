using System;
namespace Core.UI
{
    public interface IBaseView
    {
        void ShowError(Boolean isVisible);
        void ShowLoading(Boolean isVisible);
        void ShowContent(Boolean isVisible);
    }
}
