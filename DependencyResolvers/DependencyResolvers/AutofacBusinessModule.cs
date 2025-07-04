using Autofac;
using Autofac.Extras.DynamicProxy;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RentACar.Application.Behaviors.Validation.FluentValidation;
using RentACar.Application.Features.CQRS.Commands.ContactCommands;
using RentACar.Application.Features.CQRS.Handlers.Read.AboutReadHandlers;
using RentACar.Application.Features.CQRS.Handlers.Write.ContactWriteHandlers;
using RentACar.Application.Features.Services;
using RentACar.Domain.Entities.Concrete;
using RentACar.Persistence.Context;
using RentACar.Persistence.Repositories.EntityFramework.Concrete;
using System.Reflection;

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


            // For AOP (Aspect Oriented Programming) Interceptor
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new Castle.DynamicProxy.ProxyGenerationOptions()
                {
                    //Selector = new AspectInterceptorSelector()
                }).InstancePerLifetimeScope();

            // FluentValidation  Validator Register
            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
            .Where(t => t.IsClosedTypeOf(typeof(IValidator<>)))
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope();

            // MediatR Pipeline Behavior Register
            builder.RegisterGeneric(typeof(ValidationBehavior<,>))
             .As(typeof(IPipelineBehavior<,>))
             .InstancePerLifetimeScope();



        }
    }
}
