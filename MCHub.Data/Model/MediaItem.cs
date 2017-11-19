using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCHub.Data.Model
{
    public class MediaItem
    {
       
        [Key]
        public Guid MediaItemId { get; set; }

        public string FileName { get; set; }
        public string FilePath { get; set; }

        //navigation properties
        public MediaItemDetail MediaItemDetail { get; set; }
        public MetadataItem MetadataItem { get; set; }
        public RecordingDetail RecordingDetail { get; set; }
        public MetadataItemView MetadataItemView { get; set; }
    }
}
