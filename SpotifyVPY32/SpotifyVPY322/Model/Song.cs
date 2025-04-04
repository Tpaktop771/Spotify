﻿namespace SpotifyVPY322.Model;

public class Song
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string SongUrl { get; set; }
    public int AlbumId { get; set; }
    public required Album Album { get; set; }
}