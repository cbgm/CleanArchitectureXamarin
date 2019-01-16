using System;
using Autofac;

namespace Core.Core.DI
{
    public interface IComponent
    {
        void inject(ContainerBuilder builder);
    }
}
