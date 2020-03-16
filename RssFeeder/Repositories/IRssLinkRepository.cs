using System.Collections.Generic;
using System.Threading.Tasks;
using RssFeeder.Models;

namespace RssFeeder.Repositories
{
    public interface IRssLinkRepository
    {
        Task<IEnumerable<RssLink>> GetAllAsync(string userId);
    }
}
