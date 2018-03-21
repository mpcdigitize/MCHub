using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCHub
{
    public interface IParseWtvMetadataFromFile
    {

        //WtvRecording ParseFile(string filePath);
        IEnumerable<Recording> ParseFolder(IEnumerable<string> files);

       
    }
}
