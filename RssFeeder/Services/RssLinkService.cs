using System.Collections.Generic;
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

        public async Task<IEnumerable<RssLink>> GetAllAsync(string userId)
        {
            Validator.NotNullOrEmpty(userId, "The User ID is invalid");
            IEnumerable<RssLink> rssLinks = await _repository.GetAllAsync(userId);

            return rssLinks;
        }
    }
}
