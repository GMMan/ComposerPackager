using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ComposerPackager.SamplePack
{
    [XmlRoot("package")]
    public class PackageManifest
    {
        [XmlAttribute("version")]
        public int Version { get; set; }
        [XmlAttribute("author")]
        public string Author { get; set; }
        [XmlAttribute("web")]
        public string Website { get; set; }
        [XmlAttribute("description")]
        public string Description { get; set; }
        [XmlArray("samples")]
        [XmlArrayItem("sample")]
        public List<SampleEntry> Samples { get; set; }

        public PackageManifest()
        {
            Samples = new List<SampleEntry>();
        }
    }
}
