using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shell32;

namespace MCHub
{
    public class ShellParser : IParseWtvMetadataFromFile
    {

        private ShellReader _reader;
        private Dictionary<int, string> _headers;
        private Ordinal _ordinal;


        public ShellParser()
        {
            _reader = new ShellReader();
            _headers = new Dictionary<int, string>();
            _ordinal = new Ordinal();

        }

   
        public IEnumerable<WtvRecording> ParseFolder(IEnumerable<string> files)
        {
            this._ordinal = this._reader.GetFileHeaders(files.GetFirstFile()).PopulateOrdinals();

            var WtvRecordings = files.Select(p => p.GetHeaderValues(this._ordinal));
                                     
            return WtvRecordings;
        }


      

       

    }
}
