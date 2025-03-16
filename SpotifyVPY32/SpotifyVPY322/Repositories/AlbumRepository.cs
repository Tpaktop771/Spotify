using Microsoft.EntityFrameworkCore;
using SpotifyVPY322.Data;
using SpotifyVPY322.Dto.AlbumVM;
using SpotifyVPY322.Model;
using SpotifyVPY322.Repositories.Interfaces;

namespace SpotifyVPY322.Repositories;

public class AlbumRepository(SpotifyDataContext spotifyDataContext) : IAlbumRepository
{
    public async Task<List<GetAllAlbumDto>> GetAllAsync()
    {
        return await spotifyDataContext.Albums
            .Select(album => new GetAllAlbumDto
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

    public async Task AddAsync(Album album)
    {
        await spotifyDataContext.Albums.AddAsync(album);
        await spotifyDataContext.SaveChangesAsync();
    }

    public async Task<Album> GetByIdAsync(int id)
    {
        var album = spotifyDataContext.Albums.SingleAsync(artist => artist.Id == id);

        return await album;
    }

    public async Task UpdateAsync(Album album)
    {
        spotifyDataContext.Albums.Update(album);
        await spotifyDataContext.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(int id)
    {
        var album = await spotifyDataContext.Albums.FindAsync(id);
        if (album != null)
        {
            spotifyDataContext.Albums.Remove(album);
            await spotifyDataContext.SaveChangesAsync();
        }
    }
}