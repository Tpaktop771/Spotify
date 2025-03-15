using Microsoft.AspNetCore.Mvc.Rendering;

namespace SpotifyVPY322.Dto.ArtistVM;

public class CreateArtistVM
{
    public required string Title { get; set; }
    public required string PhotoUrl { get; set; }
    public required string Genre { get; set; }
    public required SelectList Genres { get; set; }
}
