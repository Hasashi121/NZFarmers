using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NZFarmers.Areas.Identity.Data;
using NZFarmers.Data;

var builder = WebApplication.CreateBuilder(args);

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

// Add services
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Seed roles
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = services.GetRequiredService<UserManager<NZFarmersUser>>();

    string[] roleNames = { "Admin", "Farmer", "Consumer" };
    foreach (var roleName in roleNames)
    {
        if (!await roleManager.RoleExistsAsync(roleName))  // ? Check if role exists before adding
        {
            await roleManager.CreateAsync(new IdentityRole(roleName));
        }
    }


    // Seed an Admin user if none exists
    if (await userManager.FindByEmailAsync("admin@nzfarmers.com") == null)
    {
        var adminUser = new NZFarmersUser
        {
            UserName = "admin@nzfarmers.com",
            Email = "admin@nzfarmers.com",
            FirstName = "Admin",
            LastName = "User",
            ContactNumber = "+1234567890",  // ✅ Added ContactNumber (Fix)
            Role = RoleType.Admin,
            EmailConfirmed = true
        };

        string adminPassword = "Admin@123"; // Change in production
        var result = await userManager.CreateAsync(adminUser, adminPassword);
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(adminUser, "Admin");
        }
    }

}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
