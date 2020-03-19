using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using RssFeeder.Models;
using RssFeeder.Repositories;
using RssFeeder.Utils;

namespace RssFeeder.Services
{
    public class RssLinkService : IRssLinkService
    {
        private readonly IRssLinkRepository _repository;
        private readonly ILogger<RssLinkService> _logger;

        public RssLinkService(IRssLinkRepository repository, ILogger<RssLinkService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public IQueryable<RssLink> GetAll(string userId)
        {
            Validator.NotNullOrEmpty(userId, "The User Id is invalid");
            IQueryable<RssLink> rssLinks = _repository.GetAll(userId);

            return rssLinks;
        }

        public async Task CreateAsync(RssLink newLink)
        {
            await _repository.CreateAsync(newLink);
        }

        public async Task DeleteAsync(RssLink link)
        {
            await _repository.DeleteAsync(link);
        }

        public async Task<RssLink> FindById(int id)
        {
            RssLink link = await _repository.FindById(id);

            return link;
        }

        public async Task SaveAsync(RssLink link)
        {
            var existingLink = await _repository.FindById(link.Id);
            if (existingLink == null)
            {
                throw new ArgumentException("The RSS Feed you are trying to edit does not exist");
            }

            if (link.Url != existingLink.Url)
            {
                existingLink.Url = link.Url;
            }

            if (link.Description != existingLink.Description)
            {
                existingLink.Description = link.Description;
            }

            await _repository.SaveAsync(existingLink);
        }
    }
}
