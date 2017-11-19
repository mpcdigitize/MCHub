using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCHub.Model
{
    public class RecordingDetail
    {
        [Key]
        public Guid RecordingDetailId { get; set; }
        public string DateReleased { get; set; }
        public string ChannelNumber { get; set; }
        public string StationName { get; set; }
        public string StationCallSign { get; set; }
        public string RecordingTime { get; set; }
        public string IsRerun { get; set; }
        public string IsProtected { get; set; }

        //navigation properties
        public Guid MediaItemId { get; set; }
    }
}
