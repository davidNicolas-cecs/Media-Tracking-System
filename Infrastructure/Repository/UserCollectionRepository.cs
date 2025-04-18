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
        //private readonly ApplicationUser _user;
        public UserCollectionRepository(ApplicationDbContext context)
        {
            _context = context;
            //_user = user;
        }
        public async Task<List<Domain.Model.UserMediaItems>> GetAllUserMediaItems(string userId)
        {
            return await _context.UserCollectionItems
                    .Where(uci => uci.UserCollection.UserId == userId) // Filter by userId
                    .Include(uci => uci.MediaItem) // Include the MediaItem
                     .Select(uci => new UserMediaItems // Project to UserMediaItems
                      {
                        MediaItemId = uci.MediaItemId,  // Map MediaItemId to MediaItem in UserMediaItems
                        Title = uci.MediaItem.Title,  // Map Title to Title in UserMediaItems
                        Genres = uci.MediaItem.Genres, // Map Genres to Genres in UserMediaItems
                        Rating = (int)uci.Rating,          // Include Rating
                        Progress = uci.Progress       // Include Progress
                     })
                     .ToListAsync();
        }
    }
}