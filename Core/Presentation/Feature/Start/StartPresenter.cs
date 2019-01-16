using System;
using System.Collections.Generic;
using Core.Domain.UseCase;
using Core.Domain.UseCase.Base;
using Core.Domain.Model;
using Core.Presentation.Mapper;
using Core.Core.DI;
using Autofac;

namespace Core.Presentation.Feature.Start
{
    public class MainPresenter : IStartPresenter
    {
        private GetReposUseCase getReposUse;
        private IStartView view;

        public MainPresenter()
        {
            using (var scope = Injector.Instance.InjectableContainer.BeginLifetimeScope())
            {
                getReposUse = scope.Resolve<GetReposUseCase>();
            }
        }

        public class GetReposObserver : BaseObserver<IStartView, List<RepoOrganization>>
        {
            public GetReposObserver(IStartView parentsView) : base(parentsView)
            {
            }

            public override void OnError(Exception error)
            {
                throw new NotImplementedException();
            }

            public override void OnNext(List<RepoOrganization> value)
            {
                this.parentsView.ShowRepo(value.ConvertAll(e => RepoOrganizationDomainMapper.Transform(e)));
            }
        }

        public void LoadRepo(string byUser)
        {
            object[] parameters = { byUser };
            getReposUse.Execute(new GetReposObserver(view), parameters);
        }

        public void OnBind()
        {
            throw new NotImplementedException();
        }

        public void OnUnbind()
        {
            getReposUse.Dispose();
        }

        public void SetView(IStartView view)
        {
            this.view = view;
        }

        public void SetUIScheduler(object scheduler)
        {
            getReposUse.SetScheduler(scheduler);
        }
    }
}
