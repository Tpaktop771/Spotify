using Spotify.Dto.Artist;

namespace Spotify.Repositories.Interfaces;

public interface IArtistRepository
{
    Task<List<GetAllArtistDto>> GetAllAsync();
    Task<GetAllArtistDto> GetDetailsAsync(int id);
}
