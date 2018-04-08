using MpcDigitize.FFmpeg.Net.Wrapper;
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


        public static IEnumerable<Recording> FixMetadataTags(this IEnumerable<Recording> recordings)
        {

            var result = recordings.Select(r => new Recording {
                Title = r.Title,
                DateReleased = r.DateReleased.ChangeTo(r.BroadcastDate).ChangeTo(r.RecordingTime).ParseYear(),
                BroadcastDate = r.BroadcastDate.ChangeTo(r.RecordingTime),
                ProgramDescription = r.ProgramDescription.ChangeTo(r.Title),
                RecordingTime = r.RecordingTime,
                Length = r.Length.ParseTotalSeconds(),
                Subtitle = r.Subtitle.ChangeTo(r.Title).ChangeTo(r.EpisodeName),
                EpisodeName = r.EpisodeName.ChangeToCustomName(r.RecordingTime),
                Size = r.Size,
                DateModified = r.DateModified,
                DateCreated = r.DateCreated,
                DateAccessed = r.DateAccessed,
                PerceivedType = r.PerceivedType,
                Genre = r.Genre,
                Rating = r.Rating,
                ProtectedRecording = r.ProtectedRecording,
                FileName = r.FileName,
                FolderName = r.FolderName,
                FolderPath = r.FolderPath,
                FilePath = r.FilePath,
                TypeRecording = r.TypeRecording,
                ParentalRating = r.ParentalRating,
                ParentalRatingReason = r.ParentalRatingReason,
                ChannelNumber = r.ChannelNumber,
                Rerun = r.Rerun,
                StationCallSign = r.StationCallSign,
                StationName = r.StationName,
                IsMovie = r.Genre.CheckGenre("Movie"),
                Thumbnail = r.Thumbnail,
                SeasonNumber = r.SeasonNumber,
                EpisodeNumber = r.EpisodeNumber


    });

           return result;

        }


        public static string CheckGenre(this string input, string genre)
        {
            string result = "";

            if (String.IsNullOrEmpty(input) || input == "0")
            {
                result = "False";

            }

            else
            {

                result = input.ToUpper().Contains(genre.ToUpper()).ToString();
            }

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

        public static string ChangeToCustomName(this string input, string replacement)
        {
            string result = "";

            if (String.IsNullOrEmpty(input) || input == "0")
            {
                result = "Episode " + replacement.ParseMonth() + "-" + replacement.ParseDay();

            }

            else
            {

                result = input;
            }

            return result;


        }


       


        public static string ParseTotalSeconds(this string time)
        {
            string totalSeconds = "0";

            TimeSpan result;

            if (TimeSpan.TryParse(time, out result))
            {
                totalSeconds = result.TotalSeconds.ToString();
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

        public static string ParseMonth(this string time)
        {
            CultureInfo culture;
            DateTimeStyles styles;
            DateTime dateResult;
            string month = "";

            styles = DateTimeStyles.AssumeLocal;

            culture = CultureInfo.CurrentCulture;

            if (DateTime.TryParse(time, culture, styles, out dateResult))
            {

                month = dateResult.Month.ToString("00");

            }
            else
            {

                month = time;
            }

            return month;

        }


        public static string ParseDay(this string time)
        {
            CultureInfo culture;
            DateTimeStyles styles;
            DateTime dateResult;
            string day = "";

            styles = DateTimeStyles.AssumeLocal;
            
            culture = CultureInfo.CurrentCulture;

            if (DateTime.TryParse(time, culture, styles, out dateResult))
            {

                day = dateResult.Day.ToString("00");

            }
            else
            {

                day = time;
            }

            return day;

        }


        public static IEnumerable<Recording> ExtractThumbnail(this IEnumerable<Recording> recordings)
        {

            var ffmpeg = new EncodingEngine(@"C:\ffmpeg\ffmpeg.exe");
            var encodingJob = new EncodingJob();
            var videoArgs = new VideoArgs();


            foreach (var recording in recordings)
            {

                var inputFile = recording.FilePath;
                var outputFile = @"C:\videos\thumbs\" + recording.FileName + ".jpg";

                int x = Int32.Parse(recording.Length);

                var timeInSeconds = x/3;

                Console.WriteLine(outputFile);
                Console.WriteLine(x);
                Console.WriteLine(timeInSeconds);
                encodingJob.Arguments = videoArgs.GetFrame(inputFile, timeInSeconds, FrameSize.SizeThumbnail,outputFile);

                ffmpeg.DoWork(encodingJob);

            }


            return recordings;


        }



    }
}
