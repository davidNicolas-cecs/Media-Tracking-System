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
        public async Task<List<UserCollectionItems>> GetAllUserMediaItems(string userId)
        {
            return await _context.UserCollectionItems
            .Include(uci => uci.MediaItem)
            .Include(uci => uci.UserCollection)
            .Where(uci => uci.UserCollection.UserId == userId)
            .ToListAsync();
        }
        public async Task AddToCollection(int mediaItemId)
        {
            var collectionItem = new UserCollectionItems{
                //id get created uniquly?
                //Progress should default to NotStarted
                // Rating should be null for now
                // need to get the user collections id

                UserCollectionId =2, //(int)_user.UserCollectionId,
                MediaItemId = mediaItemId,
            };
            _context.UserCollectionItems.Add(collectionItem);
            await _context.SaveChangesAsync();
        }
    }
}
