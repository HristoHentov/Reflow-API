using System;
using System.Collections.Generic;
using System.Linq;
using ReflowModels.ViewModels;

namespace ReflowModels.NamingModels.Tags
{
    public class AutoIncrementTag : ITag
    {
        public AutoIncrementTag()
        {
            lastValue = StartFrom - Skip; // Adding skip later in the beginning of ToString()
        }
        public int StartFrom { get; set; }

        public int Skip { get; set; }

        public bool TrailingZero { get; set; }
        private static int lastValue;

        public string ToString(string fileName, IDictionary<string, FileViewModel> files)
        {
            lastValue += Skip;
            if (TrailingZero)
                return lastValue.ToString().PadLeft(GetTrailingZeroes(files), '0');
            return lastValue.ToString();
        }

        private int GetTrailingZeroes(IDictionary<string, FileViewModel> files)
        {
            var count = files.Values.Count(f => !f.Filtered);
            var result = Math.Max(StartFrom, count * (Skip - 1) + StartFrom); // Not a good formula, but will do for now.
            return result.ToString().Length;
        }
    }
}
