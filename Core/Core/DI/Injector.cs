using System;
using System.Collections.Generic;
using Autofac;

namespace Core.Core.DI
{
    public class Injector
    {
        private static Injector instance;
        public IContainer InjectableContainer { get; set; }

        private Injector() { }

        public static Injector Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Injector();
                }
                return instance;
            }
        }

        public void Init(List<IComponent> components)
        {
            var builder = new ContainerBuilder();

            foreach (IComponent component in components)
            {
                component.inject(builder);
            }
            InjectableContainer = builder.Build();
        }
    }
}
