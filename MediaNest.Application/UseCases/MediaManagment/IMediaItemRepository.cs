using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaNest.Application.UseCases.MediaItem
{
    // DB RELATED ACTIONS
    public interface IMediaItemRepository
    {
        List<Domain.Model.MediaItem> GetAllMediaItems();
    }
}
