using System;
using System.Collections.Generic;
using Data.Repository.DataSource;
using Domain.Model;
using Domain.Repository;

namespace Data.Repository
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
