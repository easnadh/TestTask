using Microsoft.EntityFrameworkCore;
using TestTask.DAL;
using TestTask.DAL.Interfaces;
using TestTask.DAL.Repositories;
using TestTask.Service.Implementations;
using TestTask.Service.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// get the connection string from the configuration file
string connection = builder.Configuration.GetConnectionString("DefaultConnection");

// add the ApplicationContext as a service
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));

builder.Services.AddScoped<IStaffRepository, StaffRepository>();
builder.Services.AddScoped<IStaffService, StaffService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
