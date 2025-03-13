using Microsoft.EntityFrameworkCore;
using Spotify.Data;
using Spotify.Dto.Album;
using Spotify.Model;
using Spotify.Repositories.Interfaces;

namespace Spotify.Repositories;

public class AlbumRepository(SpotifyDataContext spotifyDataContext) : IAlbumRepository
{
    public async Task<List<GetAllAlbumDto>> GetAllAsync()
    {
        return await spotifyDataContext.Albums.Select(album => new GetAllAlbumDto
        {
            Id = album.Id,
            Title = album.Title,
            PhotoUrl = album.PhotoUrl
        }).ToListAsync();
    }

    public async Task<Album> GetDetailsAsync(int id)
    {
        return await spotifyDataContext.Albums
            .Include(album => album.Songs)
            .SingleAsync(album => album.Id == id);
    }
}
