using c_.DataAccess1.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using testwithapic_.Data;
using testwithapic_.Models;
using testwithapic_.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//builder.Services.AddSingleton<ISingletonGuidService, SingletonGuidService>();
//builder.Services.AddTransient<ITransientGuidServices, TransientGuideService>();
//builder.Services.AddScoped<IScopedGuideService, ScopedGuideService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IMyPropertyRepository, MyPropertyRepository>();


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
