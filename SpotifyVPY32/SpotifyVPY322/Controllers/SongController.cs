using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Spotify.Repositories.Interfaces;
using SpotifyVPY322.Dto.SongVM;
using SpotifyVPY322.Model;
using SpotifyVPY322.Repositories.Interfaces;


public class SongController : Controller
{
    private readonly ISongRepository _songRepository;
    private readonly IAlbumRepository _albumRepository;

    public SongController(ISongRepository songRepository, IAlbumRepository albumRepository)
    {
        _songRepository = songRepository;
        _albumRepository = albumRepository;
    }

    // Index: Отображение всех песен
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var songs = await _songRepository.GetAllAsync();
        return View(songs);
    }

    // Details: Отображение деталей песни
    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var song = await _songRepository.GetByIdAsync(id);
        return View(song);
    }

    // Create: Отображение формы для создания новой песни
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        var albums = await _albumRepository.GetAllAsync(); // Получаем все альбомы для выпадающего списка

        var createSongVM = new CreateSongVM
        {
            Title = string.Empty,
            SongUrl = string.Empty,
            Albums = new SelectList(albums, "Id", "Title"),
            AlbumId = 0
        };

        return View(createSongVM);
    }

    // Create: Обработка POST запроса для создания новой песни
    [HttpPost]
    public async Task<IActionResult> Create(CreateSongVM songVM)
    {
        var album = await _albumRepository.GetByIdAsync(songVM.AlbumId);

        var song = new Song
        {
            Title = songVM.Title,
            SongUrl = songVM.SongUrl,
            AlbumId = songVM.AlbumId,
            Album = album
        };

        await _songRepository.AddAsync(song);

        return RedirectToAction(nameof(Index));
    }

    // Edit: Отображение формы для редактирования песни
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var song = await _songRepository.GetByIdAsync(id);
        var albums = await _albumRepository.GetAllAsync();

        var updateSongVM = new UpdateSongVM
        {
            Id = song.Id,
            Title = song.Title,
            SongUrl = song.SongUrl,
            AlbumId = song.AlbumId,
            Albums = new SelectList(albums, "Id", "Title")
        };

        return View(updateSongVM);
    }

    // Edit: Обработка POST запроса для редактирования песни
    [HttpPost]
    public async Task<IActionResult> Edit(UpdateSongVM songVM)
    {
        var album = await _albumRepository.GetByIdAsync(songVM.AlbumId);

        var song = new Song
        {
            Id = songVM.Id,
            Title = songVM.Title,
            SongUrl = songVM.SongUrl,
            AlbumId = songVM.AlbumId,
            Album = album
        };

        await _songRepository.UpdateAsync(song);

        return RedirectToAction(nameof(Index));
    }

    // Delete: Отображение страницы подтверждения удаления песни
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var song = await _songRepository.GetByIdAsync(id);
        return View(song);
    }

    // Delete: Подтверждение и удаление песни
    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _songRepository.DeleteByIdAsync(id);
        return RedirectToAction(nameof(Index));
    }
}