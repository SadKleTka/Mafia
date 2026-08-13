using Microsoft.AspNetCore.Mvc;

namespace Mafia.Web.MVC.Areas.MainMenu.Controllers;

[Area("MainMenu")]
public class HomeController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View(); 
    }
}