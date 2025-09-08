using CityBreaks.Web.Data;
using Microsoft.EntityFrameworkCore;
using CityBreaks.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<CityBreaksContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("CityBreaks")));
builder.Services.AddScoped<ICityService, CityService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=City}/{action=Index}/{id?}");
app.Run();
