
using Microsoft.EntityFrameworkCore;
using SchoolManagementApp.MVC.Data;
using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Extensions;
using Microsoft.AspNetCore.Identity;
using SchoolManagementApp.MVC.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SchoolManagementDbContext>(x =>
{
	x.UseSqlServer(builder.Configuration.GetConnectionString("ServerLink"));
});
builder.Services.AddScoped<IAccountRepository, AccountRepository>();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<SchoolManagementDbContext>();

builder.Services.Configure<IdentityOptions>(x =>
{
	x.Password.RequiredLength = 6;
	x.Password.RequireUppercase = true;
	x.Password.RequireNonAlphanumeric = false;
	x.Password.RequiredUniqueChars = 1;
});

builder.Services.AddControllersWithViews();
builder.Services.AddNotyf(c =>
{
	c.DurationInSeconds = 5;
	c.IsDismissable = true;
	c.Position = NotyfPosition.TopRight;
});
builder.Services.ConfigureApplicationCookie(x =>
{
	x.LoginPath = "/Login";
});

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

//app.UseAuthentication();
app.UseAuthorization();
app.UseNotyf();
app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
