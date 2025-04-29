using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaNest.Domain.Model
{
    public class MediaItemSearchRequest
    {
        public string? SearchText { get; set; }

        public string Type { get; set; } = null!;

        public List<string> SelectedGenre { get; set; } = null!;

        public List<string> SelectedLangauge { get; set; } = null!;

    }
}
