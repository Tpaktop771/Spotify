using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SpotifyVPY322.Dto.Album;
using SpotifyVPY322.Model;
using SpotifyVPY322.Repositories.Interfaces;

namespace SpotifyVPY322.Controllers;

public class AlbumController : Controller
{
    private IAlbumRepository _albumRepository;
    private IArtistRepository _artistRepository;

    public AlbumController(IAlbumRepository albumRepository, IArtistRepository artistRepository)
    {
        _albumRepository = albumRepository;
        _artistRepository = artistRepository;
    }

    // Index: Отображение всех альбомов
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var albums = await _albumRepository.GetAllAsync();
        return View(albums);
    }

    // Details: Отображение деталей альбома
    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var album = await _albumRepository.GetDetailsAsync(id);
        return View(album);
    }

    // Create: Отображение формы для создания нового альбома
    [HttpGet]
    public async Task<IActionResult> Create()
    {
        var artists = await _artistRepository.GetAllAsync(); // Получаем всех артистов для выпадающего списка

        var createAlbumVM = new CreateAlbumVM
        {
            Title = string.Empty,
            PhotoUrl = string.Empty,
            ReleaseDate = DateOnly.MinValue,
            Artists = new SelectList(artists, "Id", "Title"),
            ArtistId = 0
        };

        return View(createAlbumVM);
    }

    // Create: Обработка POST запроса для создания нового альбома
    [HttpPost]
    public async Task<IActionResult> Create(
        [Bind(@$"{nameof(CreateAlbumVM.Title)}, 
               {nameof(CreateAlbumVM.PhotoUrl)}, 
               {nameof(CreateAlbumVM.ReleaseDate)}, 
               {nameof(CreateAlbumVM.ArtistId)}")]
        CreateAlbumVM albumVM)
    {
        var artist = await _artistRepository.GetByIdAsync(albumVM.ArtistId);

        var album = new Album
        {
            Title = albumVM.Title,
            PhotoUrl = albumVM.PhotoUrl,
            ReleaseDate = albumVM.ReleaseDate,
            Artist = artist,
            Songs = new List<Song>() // Инициализируем с пустым списком или добавляем песни позже
        };

        await _albumRepository.AddAsync(album);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        // Получаем список артистов для выбора
        var artists = await _artistRepository.GetAllAsync();

        // Получаем альбом по id
        var album = await _albumRepository.GetByIdAsync(id);

        // Создаем модель для редактирования
        var updateAlbumVM = new UpdateAlbumVM
        {
            Id = id,
            Title = album.Title,
            PhotoUrl = album.PhotoUrl,
            ReleaseDate = album.ReleaseDate,
            // Преобразуем список артистов в SelectList для выпадающего списка
            Artists = new SelectList(artists, "Id", "Title"),
            ArtistId = album.ArtistId // Устанавливаем текущего исполнителя
        };

        return View(updateAlbumVM);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(
        [Bind(@$"{nameof(UpdateAlbumVM.Id)}, 
             {nameof(UpdateAlbumVM.Title)}, 
             {nameof(UpdateAlbumVM.PhotoUrl)}, 
             {nameof(UpdateAlbumVM.ReleaseDate)},
             {nameof(UpdateAlbumVM.ArtistId)}")]
    UpdateAlbumVM updatedAlbumVM)
    {
        // Получаем выбранного исполнителя
        var artist = await _artistRepository.GetByIdAsync(updatedAlbumVM.ArtistId);

        // Создаем новый альбом с обновленными данными
        var album = new Album
        {
            Id = updatedAlbumVM.Id,
            Title = updatedAlbumVM.Title,
            PhotoUrl = updatedAlbumVM.PhotoUrl,
            ReleaseDate = updatedAlbumVM.ReleaseDate,
            ArtistId = updatedAlbumVM.ArtistId,
            Artist = artist,
            Songs = new List<Song>() // Инициализация пустым списком
        };

        // Обновляем альбом в репозитории
        await _albumRepository.UpdateAsync(album);

        // Направляем на страницу со списком альбомов
        var titleAlbumController = nameof(AlbumController);
        var startIndexController = titleAlbumController.IndexOf(nameof(Controller));
        var titleAlbum = titleAlbumController[..startIndexController];

        return RedirectToAction(nameof(Index), titleAlbum);
    }


    // Delete: Отображение страницы подтверждения удаления альбома
    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var album = await _albumRepository.GetByIdAsync(id);
        return View(album);
    }

    // Delete: Подтверждение и удаление альбома
    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _albumRepository.DeleteByIdAsync(id);
        return RedirectToAction(nameof(Index));
    }
}