using Microsoft.EntityFrameworkCore;
using MyIF.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Configurações para utilizar o banco de dados
builder.Services.AddDbContext<MyIFContext>(
    options => options.UseMySql(
        builder.Configuration.GetConnectionString("DB"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DB"))
    )
);

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
