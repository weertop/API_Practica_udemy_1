using API_Practica_udemy_1;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();

builder.Services.AddControllers();

//obternerla como variable de entorno
var allowedOrigins = Environment.GetEnvironmentVariable("AllowedOrigins")?.Split(",") ?? Array.Empty<string>();

//obtener allowedorigins como variable de aplicacion
//var allowedOrigins = builder.Configuration["AllowedOrigins"]?.Split(",") ?? Array.Empty<string>();

builder.Services.AddCors(options => options.AddPolicy("AllowSpecificOrigins",
                                            builder => builder.WithOrigins(allowedOrigins)
                                                              .AllowAnyHeader()
                                                              .AllowAnyMethod()));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<ApplicationDbContext>(options => 
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowSpecificOrigins");

/* codigo para ejecutar las migraciones al arracar el front, peligroso en production
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate();
}*/

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
