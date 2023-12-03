 using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using JaegerDemo_Todo.Data;
using JaegerDemo_Todo.Areas.Identity.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("JaegerDemo_DBContextConnection") ?? throw new InvalidOperationException("Connection string 'JaegerDemo_DBContextConnection' not found.");

builder.Services.AddDbContext<JaegerDemo_DBContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<JaegerDemo_DBContext>();



// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

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

app.MapRazorPages();

app.Run();
