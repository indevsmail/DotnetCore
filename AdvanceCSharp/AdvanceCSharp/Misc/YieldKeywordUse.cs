using System;
using System.Collections.Generic;
using System.Text;

namespace AdvanceCSharp.Misc
{
    public class YieldKeywordUse
    {
        public IEnumerable<int> EvenWithYield(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                if (i % 2 == 0)
                { yield return i; }
            }
            
        }

        public IEnumerable<int> EvenWithoutYield(int n)
        {
            IList<int> nlist = new List<int>();
            for (int i = 1; i <= n; i++)
            {
                if (i % 2 == 0)
                { nlist.Add(i); }
            }
            return nlist;
        }
    }
}
