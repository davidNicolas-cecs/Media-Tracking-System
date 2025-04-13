using MediaNest.Application.UseCases.MediaItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaNest.Application.UseCases.MediaManagment
{
      // Implements Additional business logic to the DB interactions. This holds the db related info that controller refrences, so here we add business logic
    public class MediaItemService
    {
        private readonly IMediaItemRepository _mediaItemRepository;

        public MediaItemService(IMediaItemRepository mediaItemRepository)
        {
            _mediaItemRepository = mediaItemRepository;
        }

        public async Task<List<Domain.Model.MediaItem>> GetMediaItemsAsync()
        {
            return await _mediaItemRepository.GetAllMediaItemsAsync();
        }

        public async Task<Domain.Model.MediaItem> GetMediaItemById(int id)
        {
            return await _mediaItemRepository.GetMediaItemById(id);
        }

        public async Task AddMediaItem(Domain.Model.MediaItem mediaItem)
        {
            await _mediaItemRepository.AddMediaItem(mediaItem);
        }

        public async Task UpdateMediaItem(Domain.Model.MediaItem mediaItem)
        {
            await _mediaItemRepository.UpdateMediaItem(mediaItem);
        }

        public async Task DeleteMediaItem(Domain.Model.MediaItem mediaItem)
        {
            await _mediaItemRepository.DeleteMediaItem(mediaItem);
        }

        public Boolean Exists(int id)
        {
            return _mediaItemRepository.Exists(id);
        }
    }
}
