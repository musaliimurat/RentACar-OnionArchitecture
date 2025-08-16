using Autofac;
using Autofac.Extensions.DependencyInjection;
using RentACar.Common.CrossCuttingConcerns.Validation;
using RentACar.Common.IoC;
using RentACar.DependencyResolvers.DependencyResolvers;
using RentACar.Infrastructure.Extensions;
using RentACar.Infrastructure.Middlewares;

var builder = WebApplication.CreateBuilder(args);


builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterModule(new AutofacBusinessModule());
});


builder.Services.AddDependencyResolvers(new ICoreModule[]
            {

                new CoreModule(),

            });

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000") 
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                      });
});


// Add services to the container.
builder.Services.AddServiceRegistration(builder.Configuration);



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();



var app = builder.Build();


app.UseCors(MyAllowSpecificOrigins);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var httpContextAccessor = app.Services.GetRequiredService<IHttpContextAccessor>();
ValidationTool.Configure(httpContextAccessor);

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ExceptionMiddleware>();

app.MapControllers();

app.Run();
