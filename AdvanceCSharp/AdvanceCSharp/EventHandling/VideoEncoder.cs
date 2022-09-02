using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AdvanceCSharp.EventHandling
{
    public class VideoEncoder
    {
        public delegate void NotifyDelegate(string title);

        public event NotifyDelegate VideoEncoded;
        public void ProcessVideo(Video video)
        {            
            Console.WriteLine("Video Encoded " + video.Title);
            Thread.Sleep(3000);

            OnVideoEncoded(video.Title);
        }

        private void OnVideoEncoded(string title)
        {
            //Call only if Event has been subscribed.
            if (VideoEncoded != null)
            {
                VideoEncoded(title);
            }
        }
    }
}
