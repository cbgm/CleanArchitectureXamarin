using System;
using Domain.Repository;
using Domain.Model;
using Domain.UseCase.Base;
using System.Collections.Generic;

namespace Domain.UseCase
{
    public class GetReposUseCase<S>: BaseUseCase<List<RepoOrganization>>
    {
        private IRepository repository;

        protected override IObservable<List<RepoOrganization>> BuildUseCaseObserable(params object[] p)
        {
            return repository.GetOrganizationRepos(p[0].ToString());
        }

        public GetReposUseCase(IRepository repository)
        {
            this.repository = repository;
        }
        /*
                public IObservable<List<RepoOrganization>> Get(String orgName)
                {
                    return repository.GetOrganizationRepos(orgName);
                }*/
    }
}
