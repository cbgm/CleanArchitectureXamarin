using System.Collections.Generic;
using Core.Core.UI;
using Core.Presentation.Model;

namespace Core.Presentation.Feature.Start
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
