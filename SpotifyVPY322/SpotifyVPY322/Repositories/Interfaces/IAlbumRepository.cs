using SpotifyVPY322.Dto.Album;
using SpotifyVPY322.Model;

namespace SpotifyVPY322.Repositories.Interfaces;

public interface IAlbumRepository
{
    Task<List<GetAllAlbumDto>> GetAllAsync();
    Task<Album> GetDetailsAsync(int id);
}