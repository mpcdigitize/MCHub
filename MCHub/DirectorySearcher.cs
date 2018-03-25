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
        private IEnumerable<Recording> _files;
         
       

        public DirectorySearcher()
        {
            _files = new List<Recording>();
            
        }


        public IEnumerable<Recording> ScanFolder(string folderPath)
        {

            _files = folderPath.GetAllFiles(searchPattern)
                    .FindNewRecordings()
                    .ParseMetadata()
                    .FixMetadataTags();
                             

            return _files;

          
        }

       
    }
}
