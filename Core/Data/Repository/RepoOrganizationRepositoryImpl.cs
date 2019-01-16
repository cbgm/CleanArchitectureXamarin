using System;
using System.Collections.Generic;
using Core.Data.Repository.DataSource;
using Core.Domain.Model;
using Core.Domain.Repository;

namespace Core.Data.Repository
{
    public class RepositoryImpl: IRepoOrganizationRepository
    {
        private IDataSource repoStore;

        public RepositoryImpl(IDataSource repoStore)
        {
            this.repoStore = repoStore;
        }

        public IObservable<List<RepoOrganization>> GetOrganizationReposByName(string orgName)
        {
            return repoStore.FetchItems(orgName);
        }
    }
}
