namespace Spotify.Dto.Album;

public class GetAllAlbumDto
{
    public required int Id { get; set; }
    public required string Title { get; set; }
    public required string PhotoUrl { get; set; }
}
