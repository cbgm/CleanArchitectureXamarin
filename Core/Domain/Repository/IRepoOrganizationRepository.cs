using System;
using System.Collections.Generic;
using Core.Domain.Model;

namespace Core.Domain.Repository
{
    public interface IRepoOrganizationRepository
    {
        IObservable<List<RepoOrganization>> GetOrganizationReposByName(string orgName);
    }
}
