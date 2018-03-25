using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMCHub.Data;

namespace MCHub
{
    class Program
    {
        static void Main(string[] args)
        {


            var searcher = new DirectorySearcher();

           //var files = searcher.ScanFolder(@"C:\RecordedTV");
         var files = searcher.ScanFolder(@"\\Htpc\d\Recorded TV");
            //var files = searcher.ScanFolder(@"\\TOWER\Media\Video\TV Soccer");
            //var context = new AppContext();

            //var repo = new Repository();

            //var parser = new ShellParser();

            //var repoService = new Repository();

            //\\Htpc\d\Recorded TV
            //IEnumerable<WtvRecording> files = repoService.ScanFolder(@"\\TOWER\Media\Video\TV Soccer");
            //IEnumerable<WtvRecording> files = repoService.ScanFolder(@"ESPN FC (2013));
            //    IEnumerable<Recording> files = repoService.ScanFolder(@"C:\RecordedTV");


            // var result = files.Where(p => p.ChannelNumber == "740");

            foreach (var item in files)
            {

                //Console.WriteLine("Title: {0} \t\n \t\n BrodcastDate: {1} \n RecordingTime: {2} \n EpisodeName: {3}\n Length: {4}\n FileName: {5}\n FilePath: {6}\n Genre: {7}\n ProtectedRec: {8}\n Rerun: {9}\n Size: {10}\n StationCallSign {11}\n StationName {12}\n Subtitle {13} \n Description {14}",
                //                                    item.Title,
                //                                    item.BroadcastDate, item.RecordingTime, item.EpisodeName,
                //                                    item.Length, item.FileName, item.FilePath, item.Genre, item.ProtectedRecording,
                //                                    item.Rerun, item.Size, item.StationCallSign, item.StationName, item.Subtitle, item.ProgramDescription
                //                                    );

                Console.WriteLine("Title: {0} \t\n \t\n BrodcastDate: {1} \n DateReleased: {2} \n Description: {3} \n RecordingTime: {4} \n Duration: {5} \n Subtitle: {6} \n Episode Name: {7}",
                                                  item.Title,
                                                  item.BroadcastDate, item.DateReleased, item.ProgramDescription, item.RecordingTime, item.Length, item.Subtitle,item.EpisodeName
                                                  );



                //  context.WtvRecordings.Add(item);
                //   context.SaveChanges();

            }


            //    repoService.SaveToDatabase(files);


            Console.ReadLine();

        }
    }
}