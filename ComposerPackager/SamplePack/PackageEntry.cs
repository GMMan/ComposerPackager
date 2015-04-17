using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComposerPackager.SamplePack
{
    public class PackageEntry
    {
        public string Name { get; set; }
        public int Length { get; set; }
        public long Offset { get; set; }
        public float SampleLength { get; set; }
    }
}
