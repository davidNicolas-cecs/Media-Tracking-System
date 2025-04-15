using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaNest.Domain.Model
{
    public class UserCollectionItems
    {
        public int Id { get; set; }
        public int UserCollectionId { get; set; }
        public UserCollection UserCollection { get; set; }

        public int MediaItemId { get; set; }
        public MediaItem MediaItem { get; set; }

        public Progress Progress { get; set; }
        public int Rating { get; set; }
    }
}

public enum Progress
{
    NotStarted,
    InProgress,
    Completed
}