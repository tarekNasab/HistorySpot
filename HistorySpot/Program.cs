using HistorySpot.Data;
using HistorySpot.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<HistorySpotDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("HistorySpotDbConnectionString")));

builder.Services.AddDbContext<AuthDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("HistorySpotAuthDbConnectionString")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AuthDbContext>();
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;
});

builder.Services.AddScoped<IHistoricalPointRepository, HistoricalPointRepository>();
builder.Services.AddScoped<ILikeRepository, LikesRepository>();

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

app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
