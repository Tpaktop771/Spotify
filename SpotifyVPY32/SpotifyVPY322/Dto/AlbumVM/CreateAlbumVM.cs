using Microsoft.AspNetCore.Mvc.Rendering;

public class CreateAlbumVM
{
    public required string Title { get; set; }
    public required string PhotoUrl { get; set; }
    public DateOnly ReleaseDate { get; set; }
    public required SelectList Artists { get; set; }
    public required int ArtistId { get; set; }
}