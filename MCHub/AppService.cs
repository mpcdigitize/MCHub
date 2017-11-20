using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMCHub.Data;

namespace MCHub
{
   public  class AppService
   {
        private AppRepo _repo;

        public AppService ()
        {

            _repo = new AppRepo;    
        }



        public static IEnumerable<MediaItem> GetMediaItems()
        { 
                
            return 
        }


   }
}
