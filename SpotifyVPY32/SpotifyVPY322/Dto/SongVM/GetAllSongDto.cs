namespace SpotifyVPY322.Dto.SongVM;

public class GetAllSongDto
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string SongUrl { get; set; }
    public required string AlbumTitle { get; set; }
}
