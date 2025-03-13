using Spotify.Model;

namespace Spotify.Repositories.Interfaces;

public interface IGenreRepository
{
    Task<List<string>> GetAllGenre();
    Task<Genre> GetByTitle(string title);
}
