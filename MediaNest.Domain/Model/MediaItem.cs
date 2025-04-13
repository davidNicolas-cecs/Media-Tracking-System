using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaNest.Domain.Model
{
    public class MediaItem
    {
        public int Id { get; set; }
        public int? ISBN { get; set; }
        public required string Title { get; set; }

        public string? Description { get; set; }

        public required string Type { get; set; }

        public int Year { get; set; }

        public required string Language { get; set; }

        public required string[] Genres { get; set; }

        public required string Rating { get; set; }
    }
}
