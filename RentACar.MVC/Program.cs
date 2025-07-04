using Autofac;
using Autofac.Extensions.DependencyInjection;
using RentACar.DependencyResolvers.DependencyResolvers;
using RentACar.Infrastructure.Middlewares;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddServiceRegistration(builder.Configuration);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddHttpContextAccessor();



builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterModule(new AutofacBusinessModule());
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseMiddleware<ExceptionMiddleware>();

app.MapControllerRoute(
     name: "areas",
     pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
   );
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
