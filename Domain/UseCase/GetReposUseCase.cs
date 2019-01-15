using System;
using Domain.Repository;
using Domain.Model;
using Domain.UseCase.Base;
using System.Collections.Generic;

namespace Domain.UseCase
{
    public class GetReposUseCase: BaseUseCase<List<RepoOrganization>>
    {
        private IRepoOrganizationRepository repository;

        protected override IObservable<List<RepoOrganization>> BuildUseCaseObserable(params object[] p)
        {
            return repository.GetOrganizationReposByName(p[0].ToString());
        }

        public GetReposUseCase(IRepoOrganizationRepository repository)
        {
            this.repository = repository;
        }
    }
}
