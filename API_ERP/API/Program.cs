var builder = WebApplication.CreateBuilder(args);

// Configurar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200", "https://kind-wave-047b9021e.6.azurestaticapps.net")
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

// Agregar controladores
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Middleware de redirección HTTPS y archivos estáticos
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting(); // ?? Primero Routing

app.UseCors("AllowAngular"); // ?? Luego CORS, antes de Authorization

app.UseAuthorization(); // ?? Ahora sí, Authorization

app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
