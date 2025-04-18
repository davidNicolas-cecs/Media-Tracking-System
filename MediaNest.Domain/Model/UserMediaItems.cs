namespace MediaNest.Domain.Model
{
    public class UserMediaItems
    {
        public int MediaItemId { get; set; }  // The ID of the MediaItem
        public string Title { get; set; }      // Title of the MediaItem
        public  string[] Genres { get; set; }   // Genres of the MediaItem
        public int Rating { get; set; }        // Rating for the MediaItem
        public Progress Progress { get; set; }      // Progress of the MediaItem
    }
}

