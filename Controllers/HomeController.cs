using Microsoft.AspNetCore.Mvc;

namespace Tp6.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
