using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
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

        [HttpGet]
        public async Task<IActionResult> ConfirmDelete(int? feedId)
        {
            if (feedId.HasValue)
            {
                return PartialView("_ConfirmDeleteModal", feedId.Value);
            }

            Response.StatusCode = 400;
            await Response.WriteAsync("RSS Feed does not exist");

            return null;
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? feedId)
        {
            if (!feedId.HasValue)
            {
                Response.StatusCode = 400;
                await Response.WriteAsync("RSS Feed does not exist");
                return null;
            }

            var linkToDelete = new RssLink {Id = feedId.Value};
            await _service.DeleteAsync(linkToDelete);

            return Json(new {redirectUrl = Url.Action("Index", "Feeds")});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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

        [HttpDelete]
        public IActionResult Delete(RssLink linkToDelete)
        {
            return RedirectToAction("Index", "Feeds");
        }
    }
}
