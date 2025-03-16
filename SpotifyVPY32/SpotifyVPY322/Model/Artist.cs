namespace SpotifyVPY322.Model;

public class Artist
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string PhotoUrl { get; set; }
    public required Genre Genre { get; set; }
    public List<Album>? Albums { get; set; }
}