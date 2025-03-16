
using SpotifyVPY322.Dto.AlbumVM;
using SpotifyVPY322.Model;

namespace SpotifyVPY322.Repositories.Interfaces;

public interface IAlbumRepository
{
    Task<List<GetAllAlbumDto>> GetAllAsync();
    Task<Album> GetDetailsAsync(int id);
    Task AddAsync(Album album);
    Task<Album> GetByIdAsync(int id);
    Task UpdateAsync(Album album);
    Task DeleteByIdAsync(int id);
}