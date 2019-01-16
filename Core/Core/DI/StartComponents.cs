using Autofac;
using Core.Data.Api;
using Core.Data.Repository;
using Core.Data.Repository.DataSource;
using Core.Domain.Repository;
using Core.Domain.UseCase;
using Core.Presentation.Feature.Start;

namespace Core.Core.DI
{
    public class StartComponents : IComponent
    {
        public void inject(ContainerBuilder builder)
        {
            builder.RegisterType<RepositoryDataSource>().As<IDataSource>();

            builder.RegisterType<RepositoryImpl>().As<IRepoOrganizationRepository>();

            builder.Register(c => new NetworkModule<ReposApi>().CreateWebService()).As<ReposApi>();

            builder.RegisterType<GetReposUseCase>().AsSelf();

            builder.RegisterType<MainPresenter>().AsSelf();
        }
    }
}
