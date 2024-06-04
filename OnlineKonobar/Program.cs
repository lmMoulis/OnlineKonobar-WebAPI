using BLL.Interface;
using BLL.Models;
using DAL;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuration
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dodajte registraciju servisa
builder.Services.AddScoped<IArtikal, ArtikalRepo>();
builder.Services.AddScoped<IKorisnik, KorisniciRepo>();
builder.Services.AddScoped<IKategorija, KategorijaRepo>();
builder.Services.AddScoped<IPrilagodba, PrilagodbaRepo>();
builder.Services.AddScoped<IStavka, StavkaRepo>();
builder.Services.AddScoped<ISkladiste, SkladisteRepo>();
builder.Services.AddScoped<IRacun, RacunRepo>();


builder.Services.AddDbContext<Data>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
