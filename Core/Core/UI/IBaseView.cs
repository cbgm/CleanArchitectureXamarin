﻿using System;
namespace Core.Core.UI
{
    public interface IBaseView
    {
        void ShowError(bool isVisible);
        void ShowLoading(bool isVisible);
        void ShowContent(bool isVisible);
    }
}
