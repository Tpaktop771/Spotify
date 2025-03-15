using Microsoft.AspNetCore.Mvc;

namespace SpotifyVPY322.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}