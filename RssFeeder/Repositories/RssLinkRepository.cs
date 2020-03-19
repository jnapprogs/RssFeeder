using System.Linq;
using System.Threading.Tasks;
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

        public IQueryable<RssLink> GetAll(string userId)
        {
            IQueryable<RssLink> rssLinks =
                _context.RssLinks.Where(link => link.OwnerId == userId);

            return rssLinks;
        }

        public async Task SaveAsync(RssLink newLink)
        {
            await _context.RssLinks.AddAsync(newLink);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(RssLink link)
        {
            _context.RssLinks.Remove(link);
            await _context.SaveChangesAsync();
        }
    }
}
