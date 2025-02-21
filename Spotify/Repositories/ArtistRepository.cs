using Microsoft.EntityFrameworkCore;
using Spotify.Data;
using Spotify.Dto.Artist;
using Spotify.Repositories.Interfaces;

namespace Spotify.Repositories;

public class ArtistRepository(SpotifyDataContext context) : IArtistRepository
{
    public async Task<List<GetAllArtistDto>> GetAllAsync()
    {
        return await context.Artists.Select(artist => new GetAllArtistDto
        {
            Id = artist.Id,
            Title = artist.Title,
            PhotoUrl = artist.PhotoUrl
        }).ToListAsync();
    }
}
