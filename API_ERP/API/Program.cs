var builder = WebApplication.CreateBuilder(args);

////////////////

// Configurar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200", "https://kind-wave-047b9021e.6.azurestaticapps.net") // Permitir Angular
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();


// Usar CORS antes de los controladores
app.UseCors("AllowAngular");

app.UseAuthorization();
app.MapControllers();
app.Run();



///////////////

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

app.UseAuthorization(); // se pone aqui otra vez por ejemplo

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
