using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RssFeeder.Models;
using RssFeeder.Resources;
using RssFeeder.Services;

namespace RssFeeder.Controllers
{
    public class FeedsController : Controller
    {
        private readonly IRssLinkService _service;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public FeedsController(IRssLinkService service, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _service = service;
            _userManager = userManager;
            _mapper = mapper;
        }
        
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            IEnumerable<RssLink> rssLinks = await _service.GetAllAsync(user.Id);
            var resources = _mapper.Map<IEnumerable<RssLink>, IEnumerable<RssLinkResource>>(rssLinks);

            return View(resources.Count());
        }
    }
}
