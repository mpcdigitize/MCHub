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

            var context = new AppContext();

            //var repo = new Repository();

            //var parser = new ShellParser();

            //var repoService = new LocalRepositoryService(repo, parser);

            ////\\Htpc\d\Recorded TV
            ////IEnumerable<WtvRecording> files = repoService.ScanFolder(@"\\TOWER\Media\Video\TV Soccer");
            ////IEnumerable<WtvRecording> files = repoService.ScanFolder(@"\\Htpc\d\Recorded TV");
            //IEnumerable<WtvRecording> files = repoService.ScanFolder(@"J:\Recorded TV");


            //// var result = files.Where(p => p.ChannelNumber == "740");

            //foreach (var item in files)
            //{

            //    Console.WriteLine("Output: {0} \t\n GUID: {1} \t\n BrodcastDate: {2} \n RecordingTime: {3} \n EpisodeName: {4}\n Length: {5}\n FileName: {6}\n FilePath: {7}\n Genre: {8}\n ProtectedRec: {9}\n Rerun: {10}\n Size: {11}\n StationCallSign {12}\n StationName {13}\n Subtitle {14} \n Description {15}",
            //                                        item.Title,
            //                                        item.WtvRecordingId, item.BroadcastDate, item.RecordingTime, item.EpisodeName,
            //                                        item.Length, item.FileName, item.FilePath, item.Genre, item.ProtectedRecording,
            //                                        item.Rerun, item.Size, item.StationCallSign, item.StationName, item.Subtitle, item.ProgramDescription
            //                                        );


            //    //  context.WtvRecordings.Add(item);
            //    //   context.SaveChanges();

            //}


            //repoService.SaveToDatabase(files);


            Console.ReadLine();

        }
    }
}