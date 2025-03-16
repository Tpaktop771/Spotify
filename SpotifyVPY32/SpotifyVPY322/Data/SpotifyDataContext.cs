using Microsoft.EntityFrameworkCore;
using SpotifyVPY322.Model;

namespace SpotifyVPY322.Data;

public class SpotifyDataContext(DbContextOptions<SpotifyDataContext> options) : DbContext(options)
{
    public DbSet<Album> Albums { get; set; }
    public DbSet<Artist> Artists { get; set; }
    public DbSet<Song> Songs { get; set; }
    public DbSet<Genre> Genres { get; set; }
}