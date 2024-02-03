using Microsoft.AspNetCore.Mvc;

namespace MeTube.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
