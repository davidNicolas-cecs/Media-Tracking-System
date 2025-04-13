using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaNest.Application.UseCases.MediaItem
{
    // DB RELATED ACTIONS Interface
    public interface IMediaItemRepository
    {
        Task<List<Domain.Model.MediaItem>> GetAllMediaItemsAsync();

        Task<Domain.Model.MediaItem> GetMediaItemById(int id);

        Task AddMediaItem(Domain.Model.MediaItem mediaItem);
        
        Task UpdateMediaItem(Domain.Model.MediaItem mediaItem);

        Task DeleteMediaItem(Domain.Model.MediaItem mediaItem);

        Boolean Exists(int id);
    }
}
