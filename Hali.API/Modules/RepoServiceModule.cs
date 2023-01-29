using Autofac;
using Hali.Core.Repositories;
using Hali.Core.Services;
using Hali.Core.UnitOfWorks;
using Hali.Repository;
using Hali.Repository.Repositories;
using Hali.Repository.UnitOfWorks;
using Hali.Service.Mapping;
using Hali.Service.Services;
using System.Reflection;

namespace Hali.API.Modules
{
    public class RepoServiceModule:Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>))
                .InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Service<,>)).As(typeof(IService<,>))
                .InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As(typeof(IUnitOfWork));


            var ApiAssembly = Assembly.GetExecutingAssembly();
            var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));
            var serviceAssembly = Assembly.GetAssembly(typeof(MapProfile));

            builder.RegisterAssemblyTypes(ApiAssembly, repoAssembly, serviceAssembly)
                    .Where(x => x.Name.EndsWith("Repository"))
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(ApiAssembly, repoAssembly, serviceAssembly)
                        .Where(x => x.Name.EndsWith("Service"))
                        .AsImplementedInterfaces()
                        .InstancePerLifetimeScope();
        }
    }
}
