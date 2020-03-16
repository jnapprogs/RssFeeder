using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RssFeeder.Models;
using RssFeeder.Services;

namespace RssFeeder.Controllers
{
    public class FeedsController : Controller
    {
        private readonly IRssLinkService _service;
        private readonly UserManager<ApplicationUser> _userManager;

        public FeedsController(IRssLinkService service, UserManager<ApplicationUser> userManager)
        {
            _service = service;
            _userManager = userManager;
        }
        
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            IEnumerable<RssLink> rssLinks = await _service.GetAllAsync(user.Id);

            return View(rssLinks.Count());
        }
    }
}
