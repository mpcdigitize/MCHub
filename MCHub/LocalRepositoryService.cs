﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMCWeb.Model;

namespace MCHub
{
    public class LocalRepositoryService
    {
        private const string searchPattern = "*.wtv";
        private IEnumerable<string> _newFiles;

        private ILocalRepository _localRepository;
        private IParseWtvMetadataFromFile _metadataFromFile;
 



        public LocalRepositoryService(ILocalRepository repo,
                                      IParseWtvMetadataFromFile metadataFromFile)
        {

            _localRepository = repo;
            _metadataFromFile = metadataFromFile;

        }


        public IEnumerable<WtvRecording> ScanFolder(string folderPath)
        {

            IEnumerable<WtvRecording> list = new List<WtvRecording>();

            var files = this._localRepository.GetAllFiles(folderPath, searchPattern);

            var newRecordings = files.GetNewRecordings();

            if (!newRecordings.IsNullOrEmpty())
            {

                list = this._metadataFromFile.ParseFolder(newRecordings);
     
                }   

                     

            return list;

          
        }


        public void SaveToDatabase(IEnumerable<WtvRecording> recordings)
        {

            var context = new AppContext();

            foreach (var recording in recordings)
            {

                var mediaItem = new MediaItem()
                {
                    MediaItemId = recording.WtvRecordingId,
                    FileName = recording.FileName,
                    FilePath = recording.FilePath

                };


                var mediaItemDetail = new MediaItemDetail()
                {
                    MediaItemDetailId = Guid.NewGuid(),
                    Size = recording.Size,
                    Duration = recording.Length,
                    DateCreated = recording.DateCreated,

                    MediaItemId = recording.WtvRecordingId,
                };


                var recordingDetail = new RecordingDetail()
                {
                    RecordingDetailId = Guid.NewGuid(),
                    DateReleased  = recording.DateReleased,
                    ChannelNumber = recording.ChannelNumber,
                    StationName = recording.StationName,
                    StationCallSign = recording.StationCallSign,
                    RecordingTime = recording.RecordingTime,
                    IsRerun = recording.Rerun,
                    IsProtected = recording.ProtectedRecording,

                    MediaItemId = recording.WtvRecordingId


                };


                var metadataItem = new MetadataItem()
                {
                    MetadataItemId = Guid.NewGuid(),
                    Title = recording.Title,
                    TitleSort = recording.Title,
                    Description = recording.ProgramDescription,
                    Genre = recording.Genre,

                    MediaItemId = recording.WtvRecordingId


                };

                context.MediaItems.Add(mediaItem);
                context.MetadataItems.Add(metadataItem);
                context.MediaItemDetails.Add(mediaItemDetail);
                context.RecordingDetails.Add(recordingDetail);
                context.SaveChanges();
            }

        }



       
    }
}
