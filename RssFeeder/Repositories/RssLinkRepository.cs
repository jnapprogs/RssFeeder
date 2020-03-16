using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RssFeeder.Data;
using RssFeeder.Models;

namespace RssFeeder.Repositories
{
    public class RssLinkRepository : IRssLinkRepository
    {
        private readonly ApplicationDbContext _context;

        public RssLinkRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RssLink>> GetAllAsync(string userId)
        {
            IEnumerable<RssLink> rssLinks = await _context.RssLinks
                .Where(link => link.OwnerId == userId)
                .ToListAsync();

            return rssLinks;
        }
    }
}
