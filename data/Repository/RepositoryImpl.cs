using System;
using System.Collections.Generic;
using Data.Repository.DataSource;
using Domain.Model;
using Domain.Repository;

namespace Data.Repository
{
    public class RepositoryImpl: IRepository
    {
        readonly IDataSource repoStore;

        public RepositoryImpl(IDataSource repoStore)
        {
            this.repoStore = repoStore;
        }

        public IObservable<List<RepoOrganization>> GetOrganizationRepos(string orgName)
        {
            return repoStore.FetchItems(orgName);
        }
    }
}
