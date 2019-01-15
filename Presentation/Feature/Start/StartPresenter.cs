using System;
using System.Collections.Generic;
using CleanArch.Droid.Feature.Start;
using Domain.UseCase;
using Domain.UseCase.Base;
using Domain.Model;
using CleanArch.Droid.Mapper;
using System.Reactive.Concurrency;
using System.Threading;

namespace Presentation
{
    public class MainPresenter<S> : IStartPresenter<S>
    {
        private GetReposUseCase<S> getReposUse;
        private IStartView view;
        private S ioScheduler;

        public MainPresenter(GetReposUseCase<S> getReposUse)
        {
            this.getReposUse = getReposUse;
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
                this.parentsView.ShowRepo(value.ConvertAll(e => RepoOrganizationDomainMapper.transform(e)));
            }
        }

        public void LoadRepo(string byUser)
        {
            object[] parameters = {byUser};
            getReposUse.Execute(new GetReposObserver(view), ioScheduler, parameters);
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

        public void SetUIScheduler(S scheduler)
        {
            this.ioScheduler = scheduler;
        }
    }
}
