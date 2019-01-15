using System;
using System.Collections.Generic;
using Data.Api;
using Domain.Model;

namespace Data.Repository.DataSource
{
    public class RepositoryDataSource: IDataSource
    {
        private ReposApi api;
        private int defaultPage = 1;
        private int perPage = 10;


        public RepositoryDataSource(ReposApi api)
        {
            this.api = api;
        }

        public IObservable<List<RepoOrganization>> FetchItems(string orgName)
        {
            return api.FetchRepos(orgName, defaultPage, perPage);
        }
    }
}