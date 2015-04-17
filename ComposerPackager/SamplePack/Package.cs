using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace ComposerPackager.SamplePack
{
    public class Package
    {
        List<PackageEntry> entries = new List<PackageEntry>();
        Stream packStream;
        object sync = new object();

        public IList<PackageEntry> Files
        {
            get
            {
                lock (sync)
                {
                    return new System.Collections.ObjectModel.ReadOnlyCollection<PackageEntry>(entries);
                }
            }
        }
        public List<string> Warnings { get; private set; }

        public Package(Stream stream)
        {
            packStream = stream;
            Warnings = new List<string>();
        }

        public void Load()
        {
            lock (sync)
            {
                packStream.Seek(0, SeekOrigin.Begin);
                BinaryReader br = new BinaryReader(packStream, Encoding.Unicode);

                Warnings.Clear();
                entries.Clear();

                int count = br.ReadInt32();
                for (int i = 0; i < count; ++i)
                {
                    PackageEntry entry = new PackageEntry();
                    int nameLength = br.ReadInt32();
                    byte[] nameBytes = br.ReadBytes(nameLength);
                    entry.Name = Encoding.Unicode.GetString(nameBytes);
                    entry.Length = br.ReadInt32();
                    entry.Offset = br.ReadInt64();
                    entry.SampleLength = br.ReadSingle();
                    entries.Add(entry);
                }
            }
        }

        public PackageManifest GetManifest()
        {
            byte[] manifestData = GetFile("info.xml");
            if (manifestData == null) return null;

            XmlSerializer ser = new XmlSerializer(typeof(PackageManifest));
            PackageManifest manifest;
            using (MemoryStream ms = new MemoryStream(manifestData))
                manifest = (PackageManifest)ser.Deserialize(ms);

            foreach (SampleEntry sample in manifest.Samples)
            {
                if (sample.StartPart != null) sample.StartPackFile = FindEntry(sample.StartPart);
                if (sample.LoopPart != null) sample.LoopPackFile = FindEntry(sample.LoopPart);
                if (sample.EndPart != null) sample.EndPackFile = FindEntry(sample.EndPart);
            }

            return manifest;
        }

        public PackageEntry FindEntry(string name)
        {
            lock (sync)
            {
                return entries.FirstOrDefault(e => e.Name == name);
            }
        }

        public byte[] GetFile(string name)
        {
            return GetFile(FindEntry(name));
        }

        public byte[] GetFile(PackageEntry entry)
        {
            if (entry == null) return null;
            if (!entries.Contains(entry)) throw new InvalidOperationException("Entry is not from this package.");

            if (entry.Offset == -1)
            {
                return File.ReadAllBytes(entry.Name);
            }
            else
            {
                lock (sync)
                {
                    BinaryReader br = new BinaryReader(packStream);
                    packStream.Seek(entry.Offset, SeekOrigin.Begin);
                    return br.ReadBytes(entry.Length);
                }
            }
        }

        public PackageEntry CreateEntry(string filename)
        {
            lock (sync)
            {
                PackageEntry entry = new PackageEntry { Name = filename, Offset = -1 };
                entries.Add(entry);
                return entry;
            }
        }

        public void RemoveEntry(PackageEntry entry)
        {
            lock (sync)
            {
                entries.Remove(entry);
            }
        }

        public void Save(string path, Action<string, int, int> progressCallback = null)
        {
            lock (sync)
            {
                if (progressCallback != null) progressCallback("Validating file names...", 0, 0);

                // Validate file names for dupes
                List<string> names = new List<string>();

                // We're going to assume there is only one level of files
                foreach (PackageEntry entry in entries)
                {
                    string normalizedName = Path.GetFileName(entry.Name).ToLowerInvariant();
                    if (names.Contains(normalizedName))
                        throw new InvalidOperationException(string.Format("Package contains multiple entries with the file name \"{0}\".", normalizedName));
                    names.Add(normalizedName);
                }

                PackageEntry manifestEntry = entries.Find(e => Path.GetFileName(e.Name) == "info.xml");
                if (manifestEntry != null)
                {
                    // Put manifest at the end of the file.
                    entries.Remove(manifestEntry);
                    entries.Add(manifestEntry);
                }
            }

            string tmpPath = Path.GetTempFileName();
            try
            {
                lock (sync)
                {
                    using (FileStream fs = File.Open(tmpPath, FileMode.Open, FileAccess.ReadWrite))
                    {
                        BinaryWriter bw = new BinaryWriter(fs);
                        BinaryReader br = new BinaryReader(packStream);

                        // Calculate starting offset
                        if (progressCallback != null) progressCallback("Preparing to save...", 0, 0);
                        long currOffset = 4;
                        foreach (PackageEntry entry in entries)
                        {
                            currOffset += 20 + Encoding.Unicode.GetByteCount(Path.GetFileName(entry.Name));
                        }

                            fs.SetLength(currOffset);
                            fs.Seek(currOffset, SeekOrigin.Begin);

                            // Copy data
                            int i = 0;
                            List<PackageEntry> newEntries = new List<PackageEntry>();
                            foreach (PackageEntry entry in entries)
                            {
                                if (progressCallback != null) progressCallback(string.Format("Copying {0}", entry.Name), i, entries.Count);
                                if (entry.Offset == -1)
                                {
                                    PackageEntry addEntry = new PackageEntry { Name = Path.GetFileName(entry.Name) };
                                    addEntry.Length = (int)new FileInfo(entry.Name).Length;
                                    addEntry.Offset = fs.Position;

                                    if (Path.GetExtension(entry.Name).ToLowerInvariant() == ".ogg")
                                    {
                                        using (NVorbis.VorbisReader vorb = new NVorbis.VorbisReader(entry.Name))
                                        {
                                            addEntry.SampleLength = (float)vorb.TotalTime.TotalSeconds;
                                        }
                                    }
                                    else
                                    {
                                        addEntry.SampleLength = 0;
                                    }

                                    newEntries.Add(addEntry);
                                    bw.Write(File.ReadAllBytes(entry.Name));
                                }
                                else
                                {
                                    newEntries.Add(new PackageEntry { Name = entry.Name, Length = entry.Length, Offset = fs.Position, SampleLength = entry.SampleLength });
                                    packStream.Seek(entry.Offset, SeekOrigin.Begin);
                                    bw.Write(br.ReadBytes(entry.Length));
                                }
                                ++i;
                            }

                            // Write header
                            if (progressCallback != null) progressCallback("Writing file table...", entries.Count, entries.Count);
                            fs.Seek(0, SeekOrigin.Begin);
                            bw.Write(newEntries.Count);

                            foreach (PackageEntry entry in newEntries)
                            {
                                byte[] nameBytes = Encoding.Unicode.GetBytes(entry.Name);
                                bw.Write(nameBytes.Length);
                                bw.Write(nameBytes);
                                bw.Write(entry.Length);
                                bw.Write(entry.Offset);
                                bw.Write(entry.SampleLength);
                            }

                        fs.Flush();
                        fs.Seek(0, SeekOrigin.Begin);

                        // Final copy to original
                        packStream.Close();
                        packStream = File.Open(path, FileMode.Create, FileAccess.ReadWrite);
                        if (progressCallback != null) progressCallback("Finalizing...", entries.Count, entries.Count);
                        fs.CopyTo(packStream);
                    }
                }

                Load();
            }
            finally
            {
                File.Delete(tmpPath);
            }
        }

        public void Close()
        {
            packStream.Close();
        }
    }
}
