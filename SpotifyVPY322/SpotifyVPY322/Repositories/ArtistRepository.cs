using Microsoft.EntityFrameworkCore;
using SpotifyVPY322.Data;
using SpotifyVPY322.Dto.ArtistVM;
using SpotifyVPY322.Model;
using SpotifyVPY322.Repositories.Interfaces;

namespace SpotifyVPY322.Repositories;

public class ArtistRepository(SpotifyDataContext context) : IArtistRepository
{
    public async Task AddAsync(Artist artist)
    {
        await context.AddAsync(artist);
        await context.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(int id)
    {
        var artist = await GetByIdAsync(id);
        context.Artists.Remove(artist);

        await context.SaveChangesAsync();
    }

    public async Task<List<GetAllArtistDto>> GetAllAsync()
    {
        var artists = await context.Artists.Select(artist => new GetAllArtistDto
        {
            Id = artist.Id,
            Title = artist.Title,
            PhotoUrl = artist.PhotoUrl
        }).ToListAsync();

        return artists;
    }

    public Task<Artist> GetByIdAsync(int id)
    {
        var artist = context.Artists.SingleAsync(artist => artist.Id == id);

        return artist;
    }

    public async Task<Artist> GetDetailsAsync(int id)
    {
        var artist = await context.Artists
                        .Include(artist => artist.Albums)
                        .SingleOrDefaultAsync(artist => artist.Id == id);

        if (artist == null)
        {
            throw new NullReferenceException();
        }

        return artist;
    }

    public async Task UpdateAsync(Artist updatedArtist, Genre genre)
    {
        var artist = await GetByIdAsync(updatedArtist.Id);

        artist.Title = updatedArtist.Title;
        artist.PhotoUrl = updatedArtist.PhotoUrl;
        artist.Genre = genre;
        artist.Albums = updatedArtist.Albums;

        await context.SaveChangesAsync();
    }
}