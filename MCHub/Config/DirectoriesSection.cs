using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCHub.Config
{
    public class DirectoriesSection : ConfigurationSection
    {

        [ConfigurationProperty("Thumbnails", DefaultValue = "false", IsRequired = false)]
        public string Database
        {
            get
            {
                return (string)this["Thumbnails"];

            }
            set
            {
                this["Thumbnails"] = value;
            }

        }

    }
}
