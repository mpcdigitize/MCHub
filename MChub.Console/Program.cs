using MpcDigitize.FFmpeg.Net.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMCHub.Data;
using System.Configuration;

namespace MCHub
{
    class Program
    {
        static void Main(string[] args)
        {

            var configManager = new Config.ConfigurationManager();
            var loc = configManager.Thumbnails;
            Console.WriteLine(loc);
            Console.ReadLine();

        //   var searcher = new DirectorySearcher();

        //   var files = searcher.ScanFolder(@"C:\RecordedTV");
       

        //    foreach (var item in files)
        //    {

        //        var ffmpeg = new EncodingEngine(@"C:\ffmpeg\ffmpeg.exe");
        //        var arguments = new EncodingArgs();
        //        var job = new EncodingJob();
        //        var vargs = new VideoArgs();


        //        Console.WriteLine("Title: {0} \t\n \t\n BrodcastDate: {1} \n DateReleased: {2} \n Description: {3} \n RecordingTime: {4}" +
        //                                    " \n Duration: {5} \n Subtitle: {6} \n Episode Name: {7} \n Genre: {8} \n IsMovie: {9} \n Input: {10} \n Output:: {11} ",
        //                                          item.Title,
        //                                          item.BroadcastDate, item.DateReleased, item.ProgramDescription, item.RecordingTime, item.Length, item.Subtitle,item.EpisodeName,
        //                                          item.Genre, item.IsMovie, item.FilePath, item.Thumbnail
        //                                          );

        //        var inputFile = item.FilePath;
        //        var outputFile = @"C:\videos\" + item.Thumbnail + " thumb" + ".jpg";


        //       // job.Arguments = vargs.Convert(inputFile, VideoEncoder.Libx264, VideoResize.TV720p, VideoPreset.VeryFast, ConstantRateFactor.CrfNormal, AudioCodec.Ac3, outputFile);
        //        job.Arguments = vargs.GetFrame(inputFile, 25, FrameSize.SizeThumbnail, outputFile);

        //        string title = "My conversion test file";

        //        job.Metadata = title;

        //        ffmpeg.VideoEncoding += DisplayProgress;
        //        ffmpeg.VideoEncoded += DisplayCompleted;
        //        ffmpeg.Exited += DisplayExitCode;


        //        ffmpeg.DoWork(job);

        //        Console.WriteLine("Completed");
              

        //        //  context.WtvRecordings.Add(item);
        //        //   context.SaveChanges();

        //    }

            

        //    //    repoService.SaveToDatabase(files);


        //    Console.ReadLine();

        //}


        //public static void DisplayProgress(object sender, EncodingEventArgs e)
        //{

        //    Console.WriteLine("Frame {0} Fps {1} Size {2} Time {3} Bitrate {4} Speed {5} Quantizer {6} Progress {7}",
        //        e.Frame, e.Fps, e.Size, e.Time, e.Bitrate, e.Speed, e.Quantizer, e.Progress);


        //}


        //public static void DisplayCompleted(object sender, EncodedEventArgs e)
        //{

        //    var meta = (string)e.EncodingJob.Metadata;
        //    Console.WriteLine("Title : {0}", meta);


        //}

        //public static void DisplayExitCode(object sender, ExitedEventArgs e)
        //{
        //    Console.WriteLine("ExitCode : {0}", e.ExitCode);


        }
    }
}