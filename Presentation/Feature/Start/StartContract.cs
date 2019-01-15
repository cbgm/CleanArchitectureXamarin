using System.Collections.Generic;
using CleanArch.Droid.Model;
using Core.UI;

namespace CleanArch.Droid.Feature.Start
{
    public interface IStartView : IBaseView
    {
        void ShowRepo(List<RepoOrganizationEntity> repos);
    }

    public interface IStartPresenter : IBasePresenter<IStartView>
    {
        void LoadRepo(string byUser);
    }
}
