using Microsoft.EntityFrameworkCore;
using TrumpsWallet.Core.Services;
using TrumpsWallet.Core.Services.Interfaces;
using TrumpsWallet.DataAccess;
using TrumpsWallet.Repositories;
using TrumpsWallet.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddControllers();

//obtengo la cadena de conexion
var connectionString = builder.Configuration.GetConnectionString("DevConnection");

//Agrego el DBContext
builder.Services.AddDbContext<WalletDbContext>(options => options.UseSqlServer(connectionString));

//agrego el servicio de Account
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IAccountService, AccountService>();

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
