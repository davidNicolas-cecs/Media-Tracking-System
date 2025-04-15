using MediaNest.Application.UseCases.UserCollectionManagment;
using MediaNest.Domain.Model;
using MediaNest.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaNest.Infrastructure.Repository
{
    public class UserCollectionRepository : IUserCollectionRepository
    {
        private readonly ApplicationDbContext _context;
        public UserCollectionRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<UserCollectionItems>> GetAllUserMediaItems(string userId)
        {
            return await _context.UserCollectionItems
            .Include(uci => uci.MediaItem)
            .Include(uci => uci.UserCollection)
            .Where(uci => uci.UserCollection.UserId == userId)
            .ToListAsync();
        }
    }
}
