using Shell32;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMCHub.Data;

namespace MCHub
{
    public static class Extensions
    {
        
        public static IEnumerable<string> GetAllFiles(this string path, string searchPattern)
        {

            var files = new List<string>();


            try
            {
                files = Directory.GetFiles(path, searchPattern, SearchOption.AllDirectories).ToList();


            }

            catch (Exception e)
            {
                Console.WriteLine("An error occurred: '{0}'", e.Message);
            }

            return files;


        }



        public static string GetFirstFile(this IEnumerable<string> files)
        {

            return files.FirstOrDefault();
        }




        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            return enumerable == null || !enumerable.Any();
        }


        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> source)
        {
            return new HashSet<T>(source);
        }


        public static IEnumerable<string> FindNewRecordings(this IEnumerable<string> files)
        {
            var context = new AppContext();

            HashSet<string> dbFiles = context.MediaItems.Select(p => p.FilePath).ToHashSet();
            HashSet<string> localFiles = files.ToHashSet();

            HashSet<string> newRecordings = new HashSet<string>(localFiles.Except(dbFiles));

            return newRecordings;

        }


        public static Recording GetHeaderValues(this string filePath, Ordinal ordinal)
        {

            ShellReader shellReader = new ShellReader();
            

            Folder folder = shellReader.GetShellFolderObject(filePath);
            FolderItem folderItem = shellReader.GetShellFolderItem(filePath);

            Recording recording = new Recording() {
               
                Size = folder.GetDetailsOf(folderItem, ordinal.Size).SanitizeString(),
                DateModified = folder.GetDetailsOf(folderItem, ordinal.DateModified).SanitizeString(),
                PerceivedType = folder.GetDetailsOf(folderItem, ordinal.PerceivedType).SanitizeString(),
                Genre = folder.GetDetailsOf(folderItem, ordinal.Genre).SanitizeString(),
                Rating = folder.GetDetailsOf(folderItem, ordinal.Rating).SanitizeString(),
                Title = folder.GetDetailsOf(folderItem, ordinal.Title).SanitizeString(),
                Length = folder.GetDetailsOf(folderItem, ordinal.Length).SanitizeString(),
                ProtectedRecording = folder.GetDetailsOf(folderItem, ordinal.ProtectedRecording).SanitizeString(),
                FileName = folder.GetDetailsOf(folderItem, ordinal.FileName).SanitizeString(),
                FolderName = folder.GetDetailsOf(folderItem, ordinal.FolderName).SanitizeString(),
                FilePath = folder.GetDetailsOf(folderItem, ordinal.FilePath).SanitizeString(),
                TypeRecording = folder.GetDetailsOf(folderItem, ordinal.TypeRecording).SanitizeString(),
                DateReleased = folder.GetDetailsOf(folderItem, ordinal.DateReleased).SanitizeString(),
                Subtitle = folder.GetDetailsOf(folderItem, ordinal.Subtitle).SanitizeString(),
                ParentalRating = folder.GetDetailsOf(folderItem, ordinal.ParentalRating).SanitizeString(),
                ParentalRatingReason = folder.GetDetailsOf(folderItem, ordinal.ParentalRatingReason).SanitizeString(),
                ChannelNumber = folder.GetDetailsOf(folderItem, ordinal.ChannelNumber).SanitizeString(),
                EpisodeName = folder.GetDetailsOf(folderItem, ordinal.EpisodeName).SanitizeString(),
                Rerun = folder.GetDetailsOf(folderItem, ordinal.Rerun).SanitizeString(),
                BroadcastDate = folder.GetDetailsOf(folderItem, ordinal.BroadcastDate).SanitizeString(),
                ProgramDescription = folder.GetDetailsOf(folderItem, ordinal.ProgramDescription).SanitizeString(),
                RecordingTime = folder.GetDetailsOf(folderItem, ordinal.RecordingTime).SanitizeString(),
                StationCallSign = folder.GetDetailsOf(folderItem, ordinal.StationCallSign).SanitizeString(),
                StationName = folder.GetDetailsOf(folderItem, ordinal.StationName).SanitizeString(),
                     };

           
       

            return recording;

        }


        //public static string GetMovieYear(this string headerValue, string broadcastDate, string recordingTime)
        //{
        //    DateTime _broadcastDate = Convert.ToDateTime(broadcastDate);
        //    DateTime _recordingTime = Convert.ToDateTime(recordingTime);


        //    string result = "";

        //    if (headerValue != "0")
        //    {
        //        result = headerValue;
        //    }

        //    if (headerValue == "0")
        //    {

        //        if (broadcastDate.ToString().Length > 0)
        //        {
        //            result = _broadcastDate.Year.ToString();

        //        }

        //        if (broadcastDate.ToString().Length == 0)
        //        {
        //            result = _recordingTime.Year.ToString();

        //        }
        //    }

        //        return result;
        //}

        public static string GetDuration(this string headerValue)
        {
            return headerValue;
        }


        public static string GetCurrentStatus(this string headerValue)
        {
            return headerValue;
        }


        public static string SanitizeString(this string headerValue)
        {
            var sanitizedString = System.Text.Encoding.ASCII.GetString(
                                        System.Text.Encoding.ASCII.GetBytes(headerValue.ToString())).Replace("?", "");

            return sanitizedString;

        }

        //public static string GetFileHeaderValue(this string filePath, int ordinal)
        //{
        //    ShellReader shellReader = new ShellReader();
            
        //    Folder folder = shellReader.GetShellFolderObject(filePath);
        //    FolderItem folderItem = shellReader.GetShellFolderItem(filePath);
        //    var header = folder.GetDetailsOf(folderItem, ordinal);

        //    return header;
        //}

        public static Ordinal PopulateOrdinals(this Dictionary<int, string> dictionary)
        {

            Ordinal ordinal = new Ordinal();

            ordinal.Size = dictionary.FirstOrDefault(p => p.Value == "Size").Key;
            ordinal.DateModified = dictionary.FirstOrDefault(p => p.Value == "Date modified").Key;
            ordinal.DateCreated = dictionary.FirstOrDefault(p => p.Value == "date created").Key;
            ordinal.DateAccessed = dictionary.FirstOrDefault(p => p.Value == "Date accessed").Key;
            ordinal.PerceivedType = dictionary.FirstOrDefault(p => p.Value == "Perceived type").Key;
            ordinal.Genre = dictionary.FirstOrDefault(p => p.Value == "Genre").Key;
            ordinal.Rating = dictionary.FirstOrDefault(p => p.Value == "Rating").Key;
            ordinal.Title = dictionary.FirstOrDefault(p => p.Value == "Title").Key;
            ordinal.Length = dictionary.FirstOrDefault(p => p.Value == "Length").Key;
            ordinal.ProtectedRecording = dictionary.FirstOrDefault(p => p.Value == "Protected").Key;
            ordinal.FileName = dictionary.FirstOrDefault(p => p.Value == "Filename").Key;
            ordinal.FolderName = dictionary.FirstOrDefault(p => p.Value == "Folder name").Key;
            ordinal.FolderPath = dictionary.FirstOrDefault(p => p.Value == "Folder path").Key;
            ordinal.FilePath = dictionary.FirstOrDefault(p => p.Value == "Path").Key;
            ordinal.TypeRecording = dictionary.FirstOrDefault(p => p.Value == "Type").Key;
            ordinal.DateReleased = dictionary.FirstOrDefault(p => p.Value == "Date released").Key;
            ordinal.Subtitle = dictionary.FirstOrDefault(p => p.Value == "Subtitle").Key;
            ordinal.ParentalRating = dictionary.FirstOrDefault(p => p.Value == "Parental rating").Key;
            ordinal.ParentalRatingReason = dictionary.FirstOrDefault(p => p.Value == "Parental rating reason").Key;
            ordinal.ChannelNumber = dictionary.FirstOrDefault(p => p.Value == "Channel number").Key;
            ordinal.EpisodeName = dictionary.FirstOrDefault(p => p.Value == "Episode name").Key;
            ordinal.Rerun = dictionary.FirstOrDefault(p => p.Value == "Rerun").Key;
            ordinal.BroadcastDate = dictionary.FirstOrDefault(p => p.Value == "Broadcast date").Key;
            ordinal.ProgramDescription = dictionary.FirstOrDefault(p => p.Value == "Program description").Key;
            ordinal.RecordingTime = dictionary.FirstOrDefault(p => p.Value == "Recording time").Key;
            ordinal.StationCallSign = dictionary.FirstOrDefault(p => p.Value == "Station call sign").Key;
            ordinal.StationName = dictionary.FirstOrDefault(p => p.Value == "Station name").Key;


            return ordinal;
           

        }
        
        public static void SaveToDatabase(this IEnumerable<Recording> recordings)
        {

            var context = new AppContext();

            foreach (var recording in recordings)
            {

                var mediaItem = new MCHub.Data.Model.MediaItem()
                {
                    MediaItemId = Guid.NewGuid(),
                    FileName = recording.FileName,
                    FilePath = recording.FilePath

                  

                };


                var mediaItemDetail = new MCHub.Data.Model.MediaItemDetail()
                {
                    MediaItemDetailId = Guid.NewGuid(),
                    Size = recording.Size,
                    Duration = recording.Length,
                    DateCreated = recording.DateCreated,

                    MediaItemId = mediaItem.MediaItemId,
                };


                var recordingDetail = new MCHub.Data.Model.RecordingDetail()
                {
                    RecordingDetailId = Guid.NewGuid(),
                    DateReleased  = recording.DateReleased,
                    ChannelNumber = recording.ChannelNumber,
                    StationName = recording.StationName,
                    StationCallSign = recording.StationCallSign,
                    RecordingTime = recording.RecordingTime,
                    IsRerun = recording.Rerun,
                    IsProtected = recording.ProtectedRecording,

                    MediaItemId = mediaItem.MediaItemId,


                };


                var metadataItem = new MCHub.Data.Model.MetadataItem()
                {
                    MetadataItemId = Guid.NewGuid(),
                    Title = recording.Title,
                    TitleSort = recording.Title,
                    Description = recording.ProgramDescription,
                    Genre = recording.Genre,

                    MediaItemId = mediaItem.MediaItemId,


                };

                var metadataItemView = new MCHub.Data.Model.MetadataItemView()
                {
                    MetadataItemViewId = Guid.NewGuid(),
                    MediaItemId = mediaItem.MediaItemId

                };



                mediaItem.MediaItemDetail = mediaItemDetail;
                mediaItem.MetadataItem = metadataItem;
                mediaItem.MetadataItemView = metadataItemView;
                mediaItem.RecordingDetail = recordingDetail;

                context.MediaItems.Add(mediaItem);
                context.MetadataItems.Add(metadataItem);
                context.MediaItemDetails.Add(mediaItemDetail);
                context.RecordingDetails.Add(recordingDetail);
                context.SaveChanges();
            }

        }
        
         public static IEnumerable<Recording> ParseMetadata(this IEnumerable<string> files)
        {
            var ordinal = new Ordinal();
            var shellReader = new ShellReader();
         
             
            ordinal = shellReader.GetFileHeaders(files.GetFirstFile()).PopulateOrdinals();

            var recordings = files.Select(p => p.GetHeaderValues(ordinal));
                                     
            return recordings;
        }


        public static IEnumerable<Recording> GetRaplacement(this IEnumerable<Recording> recordings)
        {

            var result = recordings.Select(r => new Recording {
                                        Title = r.Title,
                                        DateReleased = r.DateReleased.ChangeTo(r.BroadcastDate).ChangeTo(r.RecordingTime).ParseYear(),
                                        BroadcastDate = r.BroadcastDate.ChangeTo(r.RecordingTime),
                                        ProgramDescription = r.ProgramDescription,
                                        RecordingTime = r.RecordingTime,
                                        Length = r.Length,


            });

           return result;

        }

        public static string ChangeTo(this string input, string replacement )
        {
            string result="";

            if (String.IsNullOrEmpty(input) || input == "0")
            {
                result = replacement;

            }

            else
            {

                result = input;
            }

            return result;
            
            
        }

        public static IEnumerable<Recording> FixMetadataTags(this IEnumerable<Recording> recordings)
        {

            var rec1 = recordings.Where(r => r.DateReleased != "0")
                                   .Select(r => new Recording {
                                       Title = r.Title,
                                       DateReleased = r.DateReleased,
                                       BroadcastDate = r.RecordingTime,
                                       ProgramDescription = r.ProgramDescription,
                                       RecordingTime = r.RecordingTime
                                   });

            var rec2 = recordings.Where(r => (r.DateReleased == "0" && r.BroadcastDate !="0"))
                                  .Select(r => new Recording
                                  {
                                      Title = r.Title,
                                      DateReleased = r.BroadcastDate?.ParseYear(),
                                      BroadcastDate = r.BroadcastDate,
                                      ProgramDescription = r.ProgramDescription,
                                      RecordingTime = r.RecordingTime
                                  });


            //var rec3 = recordings.Where(r => r.DateReleased == "0" && r.BroadcastDate == "0")
            //                   .Select(r => new Recording
            //                   {
            //                       Title = r.Title,
            //                       DateReleased = r.RecordingTime?.ParseYear(),
            //                       BroadcastDate = r.BroadcastDate,
            //                       ProgramDescription = r.ProgramDescription,
            //                       RecordingTime = r.RecordingTime
            //                   });


            var recs = rec1.Concat(rec2);
                           // .Concat(rec3);

            

             return recs;

        }


        public static double ParseTotalSeconds(this string time)
        {
            double totalSeconds = 0;

            TimeSpan result;

            if (TimeSpan.TryParse(time, out result))
            {
                totalSeconds = result.TotalSeconds;
            }
            return totalSeconds;


        }

        public static string ParseYear(this string time)
        {
            CultureInfo culture;
            DateTimeStyles styles;
            DateTime dateResult;
            string year = "";

            styles = DateTimeStyles.AssumeLocal;
       
            culture = CultureInfo.CurrentCulture;

            if (DateTime.TryParse(time, culture, styles, out dateResult))
            {
       
                year = dateResult.Year.ToString();

            }
            else
            { 
       
                year = time;
            }

            return year;

        }




    }
}
