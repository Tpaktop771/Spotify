using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SpotifyVPY322.Dto.ArtistVM;
using SpotifyVPY322.Model;
using SpotifyVPY322.Repositories.Interfaces;

namespace SpotifyVPY322.Controllers;

public class ArtistController : Controller
{
    private IArtistRepository _artistRepository;
    private IGenreRepository _genreRepository;


    public ArtistController(IArtistRepository artistRepository, IGenreRepository genreRepository)
    {
        _artistRepository = artistRepository;
        _genreRepository = genreRepository;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var artists = await _artistRepository.GetAllAsync();

        return View(artists);
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var artist = await _artistRepository.GetDetailsAsync(id);

        return View(artist);
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        var genres = await _genreRepository.GetAllGenre();

        var createArtistVM = new CreateArtistVM
        {
            Title = string.Empty,
            PhotoUrl = string.Empty,
            Genre = string.Empty,
            Genres = new SelectList(genres)
        };

        return View(createArtistVM);
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        [Bind(@$"{nameof(CreateArtistVM.Title)}, 
                 {nameof(CreateArtistVM.PhotoUrl)}, 
                 {nameof(CreateArtistVM.Genre)}")]
        CreateArtistVM artistVM)
    {
        var genre = await _genreRepository.GetByTitle(artistVM.Genre);

        var artist = new Artist
        {
            Title = artistVM.Title,
            PhotoUrl = artistVM.PhotoUrl,
            Genre = genre
        };

        await _artistRepository.AddAsync(artist);

        var titleArtistController = nameof(ArtistController);
        var startIndexController = titleArtistController.IndexOf(nameof(Controller));
        var titleArtist = titleArtistController[..startIndexController];

        return RedirectToAction(nameof(Index), titleArtist);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var genres = await _genreRepository.GetAllGenre();

        var artist = await _artistRepository.GetByIdAsync(id);

        var updateArtistVM = new UpdateArtistVM
        {
            Id = id,
            Title = artist.Title,
            PhotoUrl = artist.PhotoUrl,
            Genre = string.Empty,
            Genres = new SelectList(genres)
        };

        return View(updateArtistVM);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(
        [Bind(@$"{nameof(UpdateArtistVM.Id)}, 
                 {nameof(CreateArtistVM.Title)}, 
                 {nameof(CreateArtistVM.PhotoUrl)},
                 {nameof(CreateArtistVM.Genre)}")]
        UpdateArtistVM updatedArtistVM)
    {
        var genre = await _genreRepository.GetByTitle(updatedArtistVM.Genre);

        var artist = new Artist
        {
            Id = updatedArtistVM.Id,
            Title = updatedArtistVM.Title,
            PhotoUrl = updatedArtistVM.PhotoUrl,
            Genre = genre
        };

        await _artistRepository.UpdateAsync(artist, genre);

        var titleArtistController = nameof(ArtistController);
        var startIndexController = titleArtistController.IndexOf(nameof(Controller));
        var titleArtist = titleArtistController[..startIndexController];

        return RedirectToAction(nameof(Index), titleArtist);
    }

    public async Task<IActionResult> Delete(int id)
    {
        await _artistRepository.DeleteByIdAsync(id);

        var titleArtistController = nameof(ArtistController);
        var startIndexController = titleArtistController.IndexOf(nameof(Controller));
        var titleArtist = titleArtistController[..startIndexController];

        return RedirectToAction(nameof(Index), titleArtist);
    }
}