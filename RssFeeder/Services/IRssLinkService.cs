using System.Collections.Generic;
using System.Threading.Tasks;
using RssFeeder.Models;

namespace RssFeeder.Services
{
    public interface IRssLinkService
    {
        Task<IEnumerable<RssLink>> GetAllAsync(string userId);
    }
}
