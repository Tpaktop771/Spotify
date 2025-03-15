using Spotify.Dto.ArtistVM;
using Spotify.Model;
using System.Collections;

namespace Spotify.Repositories.Interfaces;

public interface IArtistRepository
{
    Task<List<GetAllArtistDto>> GetAllAsync();
    Task<Artist> GetDetailsAsync(int id);
    Task AddAsync(Artist artist);
    Task DeleteByIdAsync(int id);
    Task<Artist> GetByIdAsync(int id);
    Task UpdateAsync(Artist artist, Genre genre);
}