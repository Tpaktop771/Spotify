using Microsoft.EntityFrameworkCore;
using Spotify.Repositories;
using Spotify.Repositories.Interfaces;
using SpotifyVPY322.Data;
using SpotifyVPY322.Repositories;
using SpotifyVPY322.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Регистрация контекста базы данных
var connection = builder.Configuration.GetConnectionString("DbConnection");
builder.Services.AddDbContext<SpotifyDataContext>(options =>
    options.UseSqlServer(connection));

// Регистрация репозиториев
builder.Services.AddScoped<IAlbumRepository, AlbumRepository>();
builder.Services.AddScoped<IArtistRepository, ArtistRepository>();
builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddScoped<ISongRepository, SongRepository>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();