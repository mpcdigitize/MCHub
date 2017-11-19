using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCHub
{
    public class WtvRecording 
    {
       [Key]
        public Guid WtvRecordingId { get; set; }
        public string Size { get; set; }
        public string DateModified { get; set; }
        public string DateCreated { get; set; }
        public string DateAccessed { get; set; }
        public string PerceivedType { get; set; }
        public string Genre { get; set; }
        public string Rating { get; set; }
        public string Title { get; set; }
        public string Length { get; set; }
        public string ProtectedRecording { get; set; }
        public string FileName { get; set; }
        public string FolderName { get; set; }
        public string FolderPath { get; set; }
        public string FilePath { get; set; }
        public string TypeRecording { get; set; }
        public string DateReleased { get; set; }
        public string Subtitle { get; set; }
        public string ParentalRating { get; set; }
        public string ParentalRatingReason { get; set; }
        public string ChannelNumber { get; set; }
        public string EpisodeName { get; set; }
        public string Rerun { get; set; }
        public string BroadcastDate { get; set; }
        public string ProgramDescription { get; set; }
        public string RecordingTime { get; set; }
        public string StationCallSign { get; set; }
        public string StationName { get; set; }
        public string IsMovie { get; set;}
        
        


        //public WtvRecording()
        //{
        //    BroadcastDate = String_NullValue;
        //    DateReleased = String_NullValue;
        //    RecordingTime = String_NullValue;
        //}

    }
}
