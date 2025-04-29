using MediaNest.Domain.Model;

namespace API.ViewModels
{
    public class MyCollectionViewModel
    {
        public List<UserMediaItems> Items { get; set; }

        public MediaItemSearchRequest SearchRequest { get; set; }
    }
}
