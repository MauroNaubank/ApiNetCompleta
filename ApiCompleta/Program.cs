using ApiCompleta.Data;
using ApiCompleta.Data.repositories;
using MySql.Data.MySqlClient;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//aqui cadena
var mySqlConfiguration = new ApiCompleta.Data.MySqlConfiguration(builder.Configuration.GetConnectionString("MySqlConnection"));

builder.Services.AddSingleton(mySqlConfiguration);



builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
//hasta aca

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
