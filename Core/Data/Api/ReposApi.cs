using System;
using System.Collections.Generic;
using Core.Domain.Model;
using Refit;

namespace Core.Data.Api
{
    public interface ReposApi
    {
        [Headers("User-Agent: Xamarin Demo App")]
        [Get("/orgs/{orgName}/repos")]
        IObservable<List<RepoOrganization>> FetchRepos(
            [AliasAs("orgName")] string orgName,
            [AliasAs("page")] int page,
            [AliasAs("per_page")] int perPage
        );
    }
}