using System;
using System.Collections.Generic;
using Domain.Model;

namespace Domain.Repository
{
    public interface IRepoOrganizationRepository
    {
        IObservable<List<RepoOrganization>> GetOrganizationReposByName(string orgName);
    }
}
