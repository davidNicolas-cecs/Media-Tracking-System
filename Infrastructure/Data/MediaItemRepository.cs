using API.Data;
using MediaNest.Application.UseCases.MediaItem;
using MediaNest.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaNest.Infrastructure.Data
{
    public class MediaItemRepository : IMediaItemRepository
    {
        private readonly ApplicationDbContext _context;

        public MediaItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<MediaItem> GetAllMediaItems()
        {
            return _context.MediaItems.ToList(); 
        }
    }
}
