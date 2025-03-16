using Microsoft.EntityFrameworkCore;
using Spotify.Repositories.Interfaces;
using SpotifyVPY322.Data;
using SpotifyVPY322.Dto.SongVM;
using SpotifyVPY322.Model;

namespace Spotify.Repositories;

public class SongRepository : ISongRepository
{
    private readonly SpotifyDataContext _context;

    public SongRepository(SpotifyDataContext context)
    {
        _context = context;
    }

    public async Task<List<GetAllSongDto>> GetAllAsync()
    {
        return await _context.Songs
            .Select(song => new GetAllSongDto
            {
                Id = song.Id,
                Title = song.Title,
                SongUrl = song.SongUrl,
                AlbumTitle = song.Album.Title
            })
            .ToListAsync();
    }

    public async Task<Song> GetByIdAsync(int id)
    {
        return await _context.Songs
            .Include(s => s.Album)
            .FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task AddAsync(Song song)
    {
        await _context.Songs.AddAsync(song);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Song song)
    {
        _context.Songs.Update(song);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(int id)
    {
        var song = await _context.Songs.FindAsync(id);
        if (song != null)
        {
            _context.Songs.Remove(song);
            await _context.SaveChangesAsync();
        }
    }
}