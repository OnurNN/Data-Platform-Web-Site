using Microsoft.EntityFrameworkCore;
using Proje.DataAccessLayer;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();

//DB Company List 
builder.Services.AddDbContext<CompanyDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefualtConnection")));
// db sector
builder.Services.AddDbContext<SectorDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("SectorConnection")));

//personal db table
builder.Services.AddDbContext<PersonalDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("PersonalConnection")));

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
