using Microsoft.EntityFrameworkCore;
using SpotifyVPY322.Data;
using SpotifyVPY322.Model;
using SpotifyVPY322.Repositories.Interfaces;

namespace SpotifyVPY322.Repositories;

public class GenreRepository : IGenreRepository
{
    private SpotifyDataContext _context;

    public GenreRepository(SpotifyDataContext context)
    {
        _context = context;
    }

    public async Task<List<string>> GetAllGenre()
    {
        var genres = await _context.Genres.Select(x => x.Title).ToListAsync();

        return genres;
    }

    public async Task<Genre> GetByTitle(string title)
    {
        var genre = await _context.Genres.SingleAsync(x => x.Title == title);

        return genre;
    }
}