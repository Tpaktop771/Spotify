using Microsoft.AspNetCore.Mvc.Rendering;

namespace SpotifyVPY322.Dto.Album;

public class UpdateAlbumVM
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string PhotoUrl { get; set; }
    public required DateOnly ReleaseDate { get; set; }
    public required int ArtistId { get; set; }
    public required SelectList Artists { get; set; }
}