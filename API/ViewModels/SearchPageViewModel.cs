using MediaNest.Domain.Model;

namespace API.ViewModels
{
    public class SearchPageViewModel
    {
        public MediaItemSearchRequest SearchRequest { get; set; }

        public List<MediaItem> SearchResult { get; set; }
    }
}
