using SpotifyVPY322.Dto.SongVM;
using SpotifyVPY322.Model;

namespace Spotify.Repositories.Interfaces;

public interface ISongRepository
{
    Task<List<GetAllSongDto>> GetAllAsync();
    Task<Song> GetByIdAsync(int id);
    Task AddAsync(Song song);
    Task UpdateAsync(Song song);
    Task DeleteByIdAsync(int id);
}