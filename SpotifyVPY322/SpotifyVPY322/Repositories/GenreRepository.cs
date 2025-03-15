using Microsoft.EntityFrameworkCore;
using Spotify.Data;
using Spotify.Model;
using Spotify.Repositories.Interfaces;

namespace Spotify.Repositories;

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
