using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCHub.Model
{
    public class MetadataItem
    {
        [Key]
        public Guid MetadataItemId { get; set; }
        public string Title { get; set; }
        public string TitleSort { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }

        //navigation properties
        public Guid MediaItemId { get; set; }

    }
}
