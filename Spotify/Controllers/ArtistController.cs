using Microsoft.AspNetCore.Mvc;
using Spotify.Repositories.Interfaces;

namespace Spotify.Controllers;

public class ArtistController(IArtistRepository artistRepository) : Controller
{
    public IActionResult Index()
    {
        var artists = artistRepository.GetAllAsync();

        return View(artists);
    }

    public IActionResult Details(int id)
    {
        var detailsArtist = artistRepository.GetDetailsAsync(id);

        return View(detailsArtist);
    }
}
