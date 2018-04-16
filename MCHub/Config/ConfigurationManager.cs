using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCHub.Config
{
    public class ConfigurationManager
    {
       
            public string Thumbnails
            {
                get
                {
                    return System.Configuration.ConfigurationManager.AppSettings["Thumbnails"];
                }
            }
        
    }
}
