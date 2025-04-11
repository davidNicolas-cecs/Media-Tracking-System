using MediaNest.Application.UseCases.MediaItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaNest.Application.UseCases.MediaManagment
{

    public class MediaItemService
    {
        private readonly IMediaItemRepository _mediaItemRepository;

        public MediaItemService(IMediaItemRepository mediaItemRepository)
        {
            _mediaItemRepository = mediaItemRepository;
        }

    }
}
