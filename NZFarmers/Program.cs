using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NZFarmers.Areas.Identity.Data;
using NZFarmers.Data;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Authentication.Google;


var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;


// Get the connection string
var connectionString = builder.Configuration.GetConnectionString("NZFarmersContextConnection")
    ?? throw new InvalidOperationException("Connection string 'NZFarmersContextConnection' not found.");

// Configure database
builder.Services.AddDbContext<NZFarmersContext>(options =>
    options.UseSqlServer(connectionString));



// Add Identity
builder.Services.AddDefaultIdentity<NZFarmersUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
.AddRoles<IdentityRole>() // Enable roles
.AddEntityFrameworkStores<NZFarmersContext>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = IdentityConstants.ApplicationScheme;
    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
})
.AddGoogle(options =>
{
    options.ClientId = configuration["Authentication:Google:ClientId"] ?? "147995618696-9r7uer4cd4itu9hbmaa1ingcqcr26kln.apps.googleusercontent.com";
    options.ClientSecret = configuration["Authentication:Google:ClientSecret"] ?? "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";

});

// Add services
builder.Services.AddControllersWithViews();



var app = builder.Build();

// Seed roles
using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    string[] roleNames = { "Admin", "Farmer", "Consumer" };

    foreach (var roleName in roleNames)
    {
        if (!await roleManager.RoleExistsAsync(roleName))
        {
            await roleManager.CreateAsync(new IdentityRole(roleName));
        }
    }
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
