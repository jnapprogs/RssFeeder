using Microsoft.AspNetCore.Mvc;

namespace RssFeeder.Controllers
{
    public class FeedsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
