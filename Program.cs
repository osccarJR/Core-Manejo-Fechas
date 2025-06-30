using DateCoreApp.Data;
using DateCoreApp.Services.Interfaces;
using DateCoreApp.Services.Implementations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Agregar EF Core con SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Agregar servicios MVC
builder.Services.AddControllersWithViews();

// ✅ PASO 9: Registrar los servicios
builder.Services.AddScoped<IDateService, DateService>();
builder.Services.AddSingleton<ISystemDateProvider>(SystemDateProvider.Instance);

var app = builder.Build();

// Configurar el middleware HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // HSTS por 30 días por defecto
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// ✅ PASO 13: Verifica enrutamiento en Program.cs (ajustado a DateLogs como controlador por defecto)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=DateLogs}/{action=Index}/{id?}");

app.Run();
