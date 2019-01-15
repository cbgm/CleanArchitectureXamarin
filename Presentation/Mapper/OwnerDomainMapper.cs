﻿using CleanArch.Droid.Model;
using Domain.Model;

namespace CleanArch.Droid.Mapper
{
    public static class OwnerDomainMapper
    {
        public static OwnerEntity Transform(Owner owner)
        {
            return new OwnerEntity(owner.login, owner.avatarUrl);
        }
    }
}
