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
        // Implementation of Interface UserRepository
        // D.I. the DB context
        private readonly ApplicationDbContext _context;
        public UserCollectionRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Domain.Model.UserMediaItems>> GetAllUserMediaItems(string userId)
        {
            // EF CORE LAZY query 
            //From userCollectionItems table, where the id = the id passed in
            // include mediaItems (aka join on mediaItem Id)
            // Create a new Object called userMediaItem that takes in SELECTED values...
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
        public async Task AddToUserCollection(int mediaId, string userId)
        {
            // get user CollectionId
            // make sure first that we dont already have an entry for this
            // *******
            var userCollectionId = await _context.UserCollections.Where(uc => uc.UserId == userId).Select(ui => (int?)ui.Id).FirstOrDefaultAsync();
            var mediaItemExists = await _context.UserCollectionItems.Where(uc => uc.UserCollectionId == userCollectionId).Where(uc => uc.MediaItemId == mediaId).Select(ui=>(int?)ui.MediaItemId).FirstOrDefaultAsync();
            Console.WriteLine(mediaItemExists);
            Console.WriteLine(userCollectionId);
            if (mediaItemExists != null)
            {
                Console.WriteLine("Found media Item already");
                return;
            }
            if (userCollectionId != null)
            {
                var data = new UserCollectionItems
                {
                    UserCollectionId = userCollectionId.Value,
                    MediaItemId = mediaId,
                    Progress = Progress.InProgress,
                    Rating = 0
                };
                _context.UserCollectionItems.Add(data);
                await _context.SaveChangesAsync();
            }

    }
}
}