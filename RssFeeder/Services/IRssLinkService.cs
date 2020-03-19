﻿using System.Linq;
using System.Threading.Tasks;
using RssFeeder.Models;

namespace RssFeeder.Services
{
    public interface IRssLinkService
    {
        IQueryable<RssLink> GetAll(string userId);
        Task CreateAsync(RssLink newLink);
        Task DeleteAsync(RssLink link);
        Task<RssLink> FindById(int id);
        Task SaveAsync(RssLink link);
    }
}
