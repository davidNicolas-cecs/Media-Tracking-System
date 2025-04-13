using API.Data;
using MediaNest.Application.UseCases.MediaItem;
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

    // Implementes and interacts with DB 
    public class MediaItemRepository : IMediaItemRepository
    {
        private readonly ApplicationDbContext _context;

        public MediaItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddMediaItem(MediaItem mediaItem)
        {
            
            _context.MediaItems.Add(mediaItem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMediaItem(MediaItem mediaItem)
        {
            _context.MediaItems.Remove(mediaItem);
            await _context.SaveChangesAsync();
        }

        public async Task<List<MediaItem>> GetAllMediaItemsAsync()
        {
            return await _context.MediaItems.ToListAsync(); 
        }

        public async Task<MediaItem> GetMediaItemById(int id)
        {
            return await _context.MediaItems.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task UpdateMediaItem(MediaItem mediaItem)
        {
            _context.MediaItems.Update(mediaItem);
            await _context.SaveChangesAsync();

        }
        public Boolean Exists(int id)
        {
            return _context.MediaItems.Any(e => e.Id == id);

        }

    }
}
