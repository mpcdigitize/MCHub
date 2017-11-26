using MCHub.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WMCHub.Data
{
    public class AppRepo
    {
        AppContext _context;


        public AppRepo()
        {

            _context = new AppContext();
        }


        public IEnumerable<MediaItem> GetMediaItems()
        {

            List<MediaItem> list = _context.MediaItems.ToList();
                
                return list;

        }


        public IEnumerable<MetadataItem> GetMetadataItems()
        {

            List<MetadataItem> list = _context.MetadataItems.ToList();

            return list;

        }


    }
}
