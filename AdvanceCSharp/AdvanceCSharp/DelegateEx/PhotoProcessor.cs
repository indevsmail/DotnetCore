using System;
using System.Collections.Generic;
using System.Text;

namespace AdvanceCSharp.DelegateEx
{
    public class PhotoProcessor
    {
        //public delegate void PhotoFilterHandler(Photo photo);
        public void Processor(string path, Action<Photo> filterHandler)
        {
            var photo = Photo.Load(path);

            #region Without Delegate                        
            /* var filter = new PhotoFilters();
            filter.ApplyBrightness(photo);
            filter.ApplyContrast(photo);
            filter.ApplyResize(photo); */
            #endregion

            #region With Delegate
            filterHandler(photo);
            #endregion

            photo.Save();
        }

        
    }
}
