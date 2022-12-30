using Microsoft.EntityFrameworkCore;
using TrumpsWallet.DataAccess;
using TrumpsWallet.Repositories.Interfaces;
using TrumpsWallet.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddControllers();

//obtengo la cadena de conexion
var connectionString = builder.Configuration.GetConnectionString("DevConnection");

//Agrego el DBContext
builder.Services.AddDbContext<WalletDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
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
