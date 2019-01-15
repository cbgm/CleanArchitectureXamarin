using System;
using System.Collections.Generic;
using Domain.Model;

namespace Domain.Repository
{
    public interface IRepository
    {
        IObservable<List<RepoOrganization>> GetOrganizationRepos(string orgName);
    }
}
