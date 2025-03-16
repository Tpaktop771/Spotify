using Microsoft.AspNetCore.Mvc.Rendering;

namespace SpotifyVPY322.Dto.SongVM;

public class UpdateSongVM
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string SongUrl { get; set; }
    public required int AlbumId { get; set; }
    public required SelectList Albums { get; set; }
}