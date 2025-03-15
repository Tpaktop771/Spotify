namespace SpotifyVPY322.Model;

public class Song
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string SongUrl { get; set; }
    public required List<Album> Albums { get; set; }
}