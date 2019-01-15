using System;
using System.Collections.Generic;
using Domain.Model;

namespace Data.Repository.DataSource
{
    public interface IDataSource
    {
        IObservable<List<RepoOrganization>> FetchItems(string orgName);
    }
}