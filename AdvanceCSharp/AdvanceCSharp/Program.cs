using AdvanceCSharp.DelegateEx;
using AdvanceCSharp.EventHandling;
using AdvanceCSharp.ExtensionMethod;
using AdvanceCSharp.Misc;
using System;

namespace AdvanceCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            #region DelegateEx
            /*
            string path = "";
            var photoProcessor = new PhotoProcessor();
            //Without Delegate
            //photoProcessor.Processor(path);

            //With Delegate
            PhotoFilters filter = new PhotoFilters();
            //PhotoProcessor.PhotoFilterHandler filterHandler = filter.ApplyBrightness;
            Action<Photo> filterHandler = filter.ApplyBrightness;
            filterHandler += filter.ApplyContrast;
            filterHandler += filter.ApplyResize;
            filterHandler += ApplyCustomCropping;

            photoProcessor.Processor(path, filterHandler);
            */
            #endregion

            #region EventHandling
            /*
            Video video = new Video() { Title = "Video 1" };
            VideoEncoder encoder = new VideoEncoder();
            var mailService = new MailingService();
            var smsService = new SMSService();

            //Subscribe Event
            encoder.VideoEncoded += mailService.SendMail;
            encoder.VideoEncoded += smsService.SendSMS;
            encoder.ProcessVideo(video);
            */
            #endregion

            #region ExtensionMethod
            /*
            string[] sArray = new string[] { "c#", "python", "java", "react" };
            string language = string.Empty;
            for (int i = 1; i <= 2; i++)
            {
                Console.WriteLine("Enter the language name: ");
                language = Console.ReadLine();
                bool isExist = language.IsExist(sArray);
                Console.WriteLine("{0} is exist: {1}", language, isExist);
            }
            */
            #endregion

            #region yield keyword
            YieldKeywordUse y = new YieldKeywordUse();
            Console.WriteLine("With using yield keyword");
            foreach(int e in y.EvenWithYield(20))
            {
                Console.WriteLine(e);
            }

            Console.WriteLine("Without using yield keyword");
            foreach (int e in y.EvenWithoutYield(20))
            {
                Console.WriteLine(e);
            }
            #endregion
            Console.ReadLine();      
        }
        public static void ApplyCustomCropping(Photo photo)
        {
            Console.WriteLine("Apply Custom cropping");
        }
    }
}
