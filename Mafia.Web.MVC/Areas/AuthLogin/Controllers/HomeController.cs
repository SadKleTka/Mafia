using Microsoft.AspNetCore.Mvc;

namespace Mafia.Web.MVC.Areas.AuthLogin.Controllers;

[Area("AuthLogin")]
public class HomeController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View(); 
    }
}