using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCHub.Data.Model
{
    public class MetadataItemView
    {
        [Key]
        public Guid MetadataItemViewId { get; set; }

        public int LibrarySectionId { get; set; }
        public int MetadataType { get; set; }
        public int EpisodeNumber { get; set; }
        public string SeriesName { get; set; }
        public string SeasonNumber { get; set; }

        //navigation properties
        public Guid MediaItemId { get; set; }

    }
}
