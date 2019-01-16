using Core.Domain.Model;
using Core.Presentation.Model;

namespace Core.Presentation.Mapper
{
    public static class OwnerDomainMapper
    {
        public static OwnerEntity Transform(Owner owner)
        {
            return new OwnerEntity(owner.login, owner.avatarUrl);
        }
    }
}
