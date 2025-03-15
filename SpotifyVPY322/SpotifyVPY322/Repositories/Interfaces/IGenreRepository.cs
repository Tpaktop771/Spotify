using SpotifyVPY322.Model;

namespace SpotifyVPY322.Repositories.Interfaces;

public interface IGenreRepository
{
    Task<List<string>> GetAllGenre();
    Task<Genre> GetByTitle(string title);
}
