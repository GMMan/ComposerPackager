using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ComposerPackager.SamplePack
{
    [XmlType("package")]
    public class SampleEntry
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlAttribute("start")]
        public string StartPart { get; set; }
        [XmlAttribute("loop")]
        public string LoopPart { get; set; }
        [XmlAttribute("end")]
        public string EndPart { get; set; }
        [XmlAttribute("description")]
        public string Description { get; set; }
        [XmlAttribute("type")]
        public string Type { get; set; }
        [XmlAttribute("tags")]
        public string TagsString
        {
            get
            {
                return string.Join(",", Tags.ToArray());
            }
            set
            {
                if (value != null)
                {
                    Tags = value.Split(',').Select(s => s.Trim()).ToList();
                }
                else
                {
                    Tags.Clear();
                }
            }
        }

        [XmlIgnore]
        public List<string> Tags { get; set; }
        [XmlIgnore]
        public PackageEntry StartPackFile { get; set; }
        [XmlIgnore]
        public PackageEntry LoopPackFile { get; set; }
        [XmlIgnore]
        public PackageEntry EndPackFile { get; set; }

        public SampleEntry()
        {
            Tags = new List<string>();
        }

        public bool ShouldSerializeStartPart()
        {
            return !string.IsNullOrEmpty(StartPart);
        }

        public bool ShouldSerializeLoopPart()
        {
            return !string.IsNullOrEmpty(LoopPart);
        }

        public bool ShouldSerializeEndPart()
        {
            return !string.IsNullOrEmpty(EndPart);
        }
    }
}
