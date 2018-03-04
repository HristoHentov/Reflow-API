using System;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using ReflowModels.ViewModels;

namespace ReflowModels.NamingModels.Tags
{
    public sealed class AutoIncrementTag : BaseTag
    {
        private static int _lastValue;

        //public AutoIncrementTag() : this(0,0, false)
        //{
        //}

        public AutoIncrementTag(int StartFrom, int skip, bool hasTrailingZero) : base(nameof(AutoIncrementTag))
        {
            this.StartFrom = StartFrom;
            this.Skip = skip;

            this.HasTrailingZero = hasTrailingZero;  
            _lastValue = this.StartFrom - Skip; // Adding skip later in the beginning of ToString()
        }

        [JsonConstructor]
        public AutoIncrementTag(int StartFrom, int Skip, bool HasTrailingZero, int Id, string Name) : base(nameof(AutoIncrementTag))
        {
            this.StartFrom = StartFrom;
            this.Skip = Skip;

            this.HasTrailingZero = HasTrailingZero;
            _lastValue = this.StartFrom - Skip; // Adding skip later in the beginning of ToString()
        }


        public int StartFrom { get; set; }

        public int Skip { get; set; }

        public bool HasTrailingZero { get; set; }


        public override string ToString(string fileName, IDictionary<string, FileViewModel> files)
        {
            _lastValue += Skip;

            return HasTrailingZero 
                ? _lastValue.ToString().PadLeft(GetTrailingZeroes(files), '0') 
                : _lastValue.ToString();
        }

        private int GetTrailingZeroes(IDictionary<string, FileViewModel> files)
        {
            if (files == null)
                return 0;

            var count = files.Values.Count(f => !f.Filtered);
            var result = Math.Max(StartFrom, count * (Skip - 1) + StartFrom); // Not a good formula, but will do for now.

            return result.ToString().Length;
        }
    }
}
