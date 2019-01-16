using Core.Domain.Model;
using Core.Presentation.Model;

namespace Core.Presentation.Mapper
{
    public static class RepoOrganizationDomainMapper
    {
        public static RepoOrganizationEntity Transform(RepoOrganization repo)
        {
            return new RepoOrganizationEntity(repo.id, repo.name, repo.description, repo.language, repo.htmlUrl, OwnerDomainMapper.Transform(repo.owner));
        }
    }
}
