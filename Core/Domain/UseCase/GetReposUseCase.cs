using System;
using Core.Domain.Repository;
using Core.Domain.Model;
using Core.Domain.UseCase.Base;
using System.Collections.Generic;

namespace Core.Domain.UseCase
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
