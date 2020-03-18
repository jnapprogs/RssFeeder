using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using RssFeeder.Models;
using RssFeeder.Repositories;
using RssFeeder.Resources;
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

        public async Task SaveAsync(RssLink newLink)
        {
            await _repository.SaveAsync(newLink);
        }
    }
}
