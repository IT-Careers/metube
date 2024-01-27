using Microsoft.AspNetCore.Mvc;

namespace MeTube.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            this.ViewData["test"] = "test";
            return View();
        }
    }
}
