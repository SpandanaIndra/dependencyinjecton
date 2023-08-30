using Microsoft.EntityFrameworkCore;
using DIDemo2.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<EmployDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("dbconnection")), ServiceLifetime.Scoped);
builder.Services.AddScoped<IEmployRepository, SQL_Crud_Employee>();
//builder.Services.AddScoped<IEmployRepository, Collection_Crud_Employee>();


WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
