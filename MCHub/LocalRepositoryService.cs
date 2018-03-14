using MCHub.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMCHub.Data;

namespace MCHub
{
    public class DirectorySearcher
    {
        private const string searchPattern = "*.wtv";
      //  private IEnumerable<string> _newFiles;
         
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

       
    }
}
