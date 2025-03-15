using Microsoft.EntityFrameworkCore;
using SpotifyVPY322.Data;
using SpotifyVPY322.Repositories;
using SpotifyVPY322.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var connection = builder.Configuration.GetConnectionString("DbConnection");
builder.Services.AddDbContext<SpotifyDataContext>(options =>
    options.UseSqlServer(connection));

builder.Services.AddScoped<IAlbumRepository, AlbumRepository>();
builder.Services.AddScoped<IArtistRepository, ArtistRepository>();
builder.Services.AddScoped<IGenreRepository, GenreRepository>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();