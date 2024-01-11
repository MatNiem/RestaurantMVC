using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RestaurantMVC.Data;
using RestaurantMVC.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<RestaurantMVCContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("RestaurantMVCContext") ?? throw new InvalidOperationException("Connection string 'RestaurantMVCContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<RestaurantMVCContext>(options => options.UseSqlite("Data Source=Baza.db"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        SeedData.Initialize(services);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occured seeding the DB.");
    }
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dish}/{action=Index}/{id?}");

app.Run();
