using API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Agregamos la conexiondeelservidor
//"ConnectionString": {
//    "Minombredeconexion": "Server=srv863.hstgr.io;Port=3306;User=u484426513_pac324;Password=B&XWouC#9Ef;Database=u484426513_pac324;"
//  }
var connectionString = builder.Configuration.GetConnectionString("Minombredeconexion");

//hay que agregarlo al servicio
builder.Services.AddDbContext<MinombredeconexionDbContext>(
    options =>
        options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 21))
    ));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
