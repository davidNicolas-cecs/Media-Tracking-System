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
        public async Task<List<Domain.Model.UserMediaItems>> GetAllUserMediaItems(string userId)
        {
            return await _context.UserCollectionItems
                    .Where(uci => uci.UserCollection.UserId == userId) 
                    .Include(uci => uci.MediaItem) 
                     .Select(uci => new UserMediaItems 
                      {
                        MediaItemId = uci.MediaItemId, 
                        Title = uci.MediaItem.Title, 
                        Genres = uci.MediaItem.Genres,
                        Rating = (int)uci.Rating,          
                        Progress = uci.Progress       
                     })
                     .ToListAsync();
        }

        // Add Media Item to Collection
        // _context.UserCollectionItems,Add();
    }
}