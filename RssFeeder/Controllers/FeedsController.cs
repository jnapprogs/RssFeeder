using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RssFeeder.Models;
using RssFeeder.Resources;
using RssFeeder.Services;
using RssFeeder.Utils;

namespace RssFeeder.Controllers
{
    public class FeedsController : Controller
    {
        private readonly IRssLinkService _service;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IRssParser _parser;

        public FeedsController(IRssLinkService service, UserManager<ApplicationUser> userManager, IMapper mapper, IRssParser parser)
        {
            _service = service;
            _userManager = userManager;
            _mapper = mapper;
            _parser = parser;
        }
        
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            IQueryable<RssLink> rssLinks = _service.GetAll(user.Id);
            IEnumerable<RssLinkResource> resources = await _parser.ParseAsync(rssLinks);

            return View(resources);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var resource = new NewRssLinkResource();

            return View(resource);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] NewRssLinkResource resource)
        {
            if (!ModelState.IsValid)
            {
                return View(resource);
            }
            
            var user = await _userManager.GetUserAsync(HttpContext.User);
            RssLink newLink = _mapper.Map<NewRssLinkResource, RssLink>(resource);
            newLink.OwnerId = user.Id;

            await _service.SaveAsync(newLink);

            return RedirectToAction(nameof(Index), "Feeds");
        }

        [HttpPost]
        public IActionResult CreateNewLink([FromForm] NewRssLinkResource resource)
        {
            if (!ModelState.IsValid)
            {
                var item = new PartialViewResult();
                return PartialView("_NewFeedModal", resource);

                /*Dictionary<string, string> items = ModelState.ExtractErrors();
                return new JsonResult(items);*/
            }

            return RedirectToAction(nameof(Index), "Feeds");
        }
    }
}
