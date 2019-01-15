using System;
using CleanArch.Droid.Model;
using Domain.Model;
namespace CleanArch.Droid.Mapper
{
    public static class RepoOrganizationDomainMapper
    {
        public static RepoOrganizationEntity transform(RepoOrganization repo)
        {
            return new RepoOrganizationEntity(repo.id, repo.name, repo.description, repo.language, repo.html_url, OwnerDomainMapper.transform(repo.owner));
        }
    }
}
