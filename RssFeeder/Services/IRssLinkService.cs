using System.Linq;
using System.Threading.Tasks;
using RssFeeder.Models;
using RssFeeder.Resources;

namespace RssFeeder.Services
{
    public interface IRssLinkService
    {
        IQueryable<RssLink> GetAll(string userId);
        Task SaveAsync(RssLink newLink);
    }
}
