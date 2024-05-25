using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PFA.Context;
using PFA.Visite;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<MyContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddSession
(opt => { 
		opt.IdleTimeout = TimeSpan.FromMinutes(20);
	opt.Cookie.HttpOnly = true;
	opt.Cookie.Name = "MaSession";
});
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddControllersWithViews()
        .AddNewtonsoftJson(options =>
        {
            options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        });
builder.Services.AddScoped<IVisitService, VisitService>();
// Enregistrer VisitService comme service injecté
builder.Services.AddScoped<VisitService>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); // Assurez-vous que ceci est ajouté

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
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

   
});

app.Run();
