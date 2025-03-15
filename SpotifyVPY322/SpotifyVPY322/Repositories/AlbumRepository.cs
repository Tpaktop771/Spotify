using Microsoft.EntityFrameworkCore;
using SpotifyVPY322.Data;
using SpotifyVPY322.Dto.Album;
using SpotifyVPY322.Model;
using SpotifyVPY322.Repositories.Interfaces;

namespace SpotifyVPY322.Repositories;

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