namespace SpotifyVPY322.Dto.ArtistVM;

public class GetAllArtistDto
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string PhotoUrl { get; set; }
}