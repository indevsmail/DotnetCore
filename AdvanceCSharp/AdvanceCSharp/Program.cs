using AdvanceCSharp.DelegateEx;
using System;

namespace AdvanceCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
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
            Console.ReadLine();      
        }

        public static void ApplyCustomCropping(Photo photo)
        {
            Console.WriteLine("Apply Custom cropping");
        }
    }
}
