namespace SpotifyVPY322.Model;

public class Album
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string PhotoUrl { get; set; }
    public DateOnly ReleaseDate { get; set; }
    public required Artist Artist { get; set; }
    public required List<Song> Songs { get; set; }
}