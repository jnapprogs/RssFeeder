﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RssFeeder.Models;

namespace RssFeeder.Repositories
{
    public interface IRssLinkRepository
    {
        IQueryable<RssLink> GetAll(string userId);
        Task SaveAsync(RssLink newLink);
        Task DeleteAsync(RssLink link);
    }
}
