using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shell32;

namespace MCHub
{
    public class ShellReader
    {

        List<string> arrHeaders = new List<string>();
        private const int headersUpperLimit = 500;

  

        public Folder GetShellFolderObject(string filePath)
        {
           
                Type shellAppType = Type.GetTypeFromProgID("Shell.Application");
                Object shell = Activator.CreateInstance(shellAppType);
                Folder folder = (Folder)shellAppType.InvokeMember("NameSpace",
                    System.Reflection.BindingFlags.InvokeMethod, null, shell, new[] { System.IO.Directory.GetParent(filePath).FullName });

            return folder;
        }


        public FolderItem GetShellFolderItem(string filePath)
        {
            Folder folder = this.GetShellFolderObject(filePath);
            FolderItem folderItem = folder.ParseName(System.IO.Path.GetFileName(filePath));

            return folderItem;

        }


        public Dictionary<int, string> GetFileHeaders(string filePath)
        {

            Folder folder = this.GetShellFolderObject(filePath);
            Dictionary<int, string> headers = new Dictionary<int, string>();

            for (int i = 0; i < headersUpperLimit; i++)
            {
                string header = folder.GetDetailsOf(null, i);
               
              headers.Add(i, header);
          
              
            }

            return headers;

        }


       



        

    }
}
