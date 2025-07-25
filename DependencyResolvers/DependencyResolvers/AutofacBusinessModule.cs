using Autofac;
using Autofac.Extras.DynamicProxy;
using AutoMapper;
using Castle.DynamicProxy;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RentACar.Application.Features.Services;
using RentACar.Application.Interfaces.Services;
using RentACar.Common.Interceptors;
using RentACar.Persistence.Context;
using RentACar.Persistence.Repositories.EntityFramework.Concrete;

namespace RentACar.DependencyResolvers.DependencyResolvers
{
    public class AutofacBusinessModule : Autofac.Module
    {
        //DL => Dependency Injection managment
        protected override void Load(ContainerBuilder builder)
        {

            // Persistence Layer for Register Repository
            //builder.RegisterType<EfAboutRepository>().As<IAboutRepository>().InstancePerLifetimeScope();
            //builder.RegisterType<EfBannerRepository>().As<IBannerRepository>().InstancePerLifetimeScope();


            // DbContext Connection string 
            builder.Register(context =>
            {
                var configuration = context.Resolve<IConfiguration>(); // IConfiguration 
                var optionsBuilder = new DbContextOptionsBuilder<RentACarContext>();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection")); // Connection String al
                return new RentACarContext(optionsBuilder.Options);
            }).AsSelf().InstancePerLifetimeScope();



            //Generic Repository DAL => Data Access Layer register
            builder.RegisterAssemblyTypes(typeof(EfRepositoryBase<,>).Assembly)
              .Where(t => t.Name.EndsWith("Repository"))
              .AsImplementedInterfaces()
              .InstancePerLifetimeScope();

            //Manager Register for Business Layer
            builder.RegisterAssemblyTypes(typeof(AboutManager).Assembly)
               .Where(t => t.Name.EndsWith("Manager"))
               .AsImplementedInterfaces()
               .InstancePerLifetimeScope();

            // CQRS Handlers Automatic Register for (Command and Query)
            //builder.RegisterAssemblyTypes(typeof(GetAllAboutQueryHandler).Assembly)
            //   .Where(t => t.Name.EndsWith("Handler"))
            //   .AsSelf()
            //   .InstancePerLifetimeScope();


            //MediatR Service Register
            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
             .AsClosedTypesOf(typeof(IRequestHandler<,>))
             .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                .AsClosedTypesOf(typeof(INotificationHandler<>))
                .InstancePerLifetimeScope();



            //For AutoMapper configuration
            builder.Register(ctx =>
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddMaps(AppDomain.CurrentDomain.GetAssemblies());
                });

                return config;
            }).AsSelf().SingleInstance();

            builder.Register(ctx =>
            {
                var scope = ctx.Resolve<IComponentContext>();
                var config = scope.Resolve<MapperConfiguration>();
                return config.CreateMapper(scope.Resolve);
            }).As<IMapper>().InstancePerLifetimeScope();

            // Application qatındakı Manager-lər üçün Assembly
            var applicationAssembly = typeof(IBrandService).Assembly;

            // Aspect-lər üçün Common və ya digər AOP yazdığımiz layihənin assembly-si (məs: RentACar.Common)
            var commonAssembly = typeof(AspectInterceptorSelector).Assembly;

            // Register edərkən düzgün assembly-ləri ver
            builder.RegisterAssemblyTypes(applicationAssembly, commonAssembly)
                .Where(t => t.Name.EndsWith("Manager"))
                .AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions
                {
                    Selector = new AspectInterceptorSelector()
                })
                .InstancePerLifetimeScope();


        }
    }
}
