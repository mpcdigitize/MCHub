using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCHub
{
    public interface ILocalRepository
    {

        IEnumerable<string> GetAllFiles(string path, string searchPattern);
       
    }
}
