using SpotifyVPY322.Dto.ArtistVM;
using SpotifyVPY322.Model;
using System.Collections;

namespace SpotifyVPY322.Repositories.Interfaces;

public interface IArtistRepository
{
    Task<List<GetAllArtistDto>> GetAllAsync();
    Task<Artist> GetDetailsAsync(int id);
    Task AddAsync(Artist artist);
    Task DeleteByIdAsync(int id);
    Task<Artist> GetByIdAsync(int id);
    Task UpdateAsync(Artist artist, Genre genre);
}