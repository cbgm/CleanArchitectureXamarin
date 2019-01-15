using CleanArch.Droid.Model;
using Domain.Model;
namespace CleanArch.Droid.Mapper
{
    public static class RepoOrganizationDomainMapper
    {
        public static RepoOrganizationEntity Transform(RepoOrganization repo)
        {
            return new RepoOrganizationEntity(repo.id, repo.name, repo.description, repo.language, repo.htmlUrl, OwnerDomainMapper.Transform(repo.owner));
        }
    }
}
