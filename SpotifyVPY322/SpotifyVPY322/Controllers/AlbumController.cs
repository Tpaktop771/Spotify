using Microsoft.AspNetCore.Mvc;
using SpotifyVPY322.Repositories.Interfaces;

namespace SpotifyVPY322.Controllers;

public class AlbumController(IAlbumRepository albumRepository) : Controller
{
    public async Task<IActionResult> Index()
    {
        var album = await albumRepository.GetAllAsync();

        return View(album);
    }

    public async Task<IActionResult> Details(int id)
    {
        var detailsdAlbum = await albumRepository.GetDetailsAsync(id);

        return View(detailsdAlbum);
    }
}