using Microsoft.AspNetCore.Mvc;

namespace Mafia.Web.MVC.Areas.AuthRegister.Controllers;

[Area("AuthRegister")]
public class HomeController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View(); 
    }
}