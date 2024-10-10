using c_.DataAccess1.Repository;
using c_.DataAccess1.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using testwithapic_.Data;
using testwithapic_.Models;
using testwithapic_.Services;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddRazorPages();
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();
//builder.Services.AddSingleton<ISingletonGuidService, SingletonGuidService>();
//builder.Services.AddTransient<ITransientGuidServices, TransientGuideService>();
//builder.Services.AddScoped<IScopedGuideService, ScopedGuideService>();
//builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
//builder.Services.AddScoped<IMyPropertyRepository, MyPropertyRepository>();
//builder.Services.AddScoped<IArticlesRepository, ArticalesRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


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
app.MapRazorPages(); 
app.MapControllerRoute(
    name: "default",
    pattern: "{area=Shinigami_5}/{controller=Home}/{action=Index}/{id?}");

app.Run();
