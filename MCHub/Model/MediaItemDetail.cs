using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCHub.Model
{
    public class MediaItemDetail
    {
        [Key]
        public Guid MediaItemDetailId { get; set; }
        public string Size { get; set; }
        public string Duration { get; set; }
        public string DateCreated { get; set; }

        //navigation properties
        public Guid MediaItemId { get; set; }

    }
}
