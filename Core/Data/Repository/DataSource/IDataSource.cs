using System;
using System.Collections.Generic;
using Core.Domain.Model;

namespace Core.Data.Repository.DataSource
{
    public interface IDataSource
    {
        IObservable<List<RepoOrganization>> FetchItems(string orgName);
    }
}