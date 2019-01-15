using System;
using System.Collections.Generic;
using Domain.Model;
using Refit;

namespace Data.Api
{
    public interface ReposApi
    {
        [Headers("User-Agent: Xamarin Demo App")]
        [Get("/orgs/{orgName}/repos")]
        IObservable<List<RepoOrganization>> FetchRepos(
            [AliasAs("orgName")] string orgName,
            [AliasAs("page")] int page,
            [AliasAs("per_page")] int per_page
        );
    }

    /*public interface IApiFactory<T>
    {
        T Create();
    }*/
}