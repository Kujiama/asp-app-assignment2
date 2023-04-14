using Assignment2.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Assignment2.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddRouting(options =>
{
    options.AppendTrailingSlash = true;
    options.LowercaseUrls = true;

});

builder.Services.AddDbContext<Assign2DBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("StockDatabase")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<Assign2DBContext>()
    .AddDefaultUI()
    .AddDefaultTokenProviders();

    

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();



var app = builder.Build();

//Seed Roles
using var scope = app.Services.CreateScope();
var loggerFactory = scope.ServiceProvider.GetRequiredService<ILoggerFactory>();

try
{
    Assign2DBContext context = scope.ServiceProvider.GetRequiredService<Assign2DBContext>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
	var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    await ContextSeed.SeedRolesAsync(userManager, roleManager);
    await ContextSeed.SeedSuperAdminAsync(userManager, roleManager);
	await ContextSeed.SeedAdminAsync(userManager, roleManager);
	await ContextSeed.SeedBuyerRolesAsync(userManager, roleManager);
	await ContextSeed.SeedSellerRolesAsync(userManager, roleManager);

}
catch(Exception e)
{
    var logger = loggerFactory.CreateLogger<Program>();
    logger.LogError(e, "An error occured seeding the roles for the system.");
}




// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.MapRazorPages();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
