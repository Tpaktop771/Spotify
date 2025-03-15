using Spotify.Dto.Album;
using Spotify.Model;

namespace Spotify.Repositories.Interfaces;

public interface IAlbumRepository
{
    Task<List<GetAllAlbumDto>> GetAllAsync();
    Task<Album> GetDetailsAsync(int id);
}