using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using ComposerPackager.SamplePack;

namespace ComposerPackager
{
    public partial class MainForm : Form
    {
        Package pack;
        //SampleBank bank;
        SampleEntry curEntry;
        PackageManifest manifest;
        ListViewItem itm;

        public MainForm()
        {
            InitializeComponent();
        }

        private void newPackButton_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    Package newpack = new Package(File.Create(saveFileDialog.FileName));
                    writeManifest(new PackageManifest { Version = 1 });
                    newpack.CreateEntry(Path.Combine(Path.GetTempPath(), "info.xml"));
                    newpack.Save(saveFileDialog.FileName);
                    newpack.Close();
                    openFileDialog.FileName = saveFileDialog.FileName;
                    openFile();
                    MessageBox.Show(this, "New package created.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Couldn't create new package: " + ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (File.Exists(Path.Combine(Path.GetTempPath(), "info.xml"))) File.Delete(Path.Combine(Path.GetTempPath(), "info.xml"));
                }
            }
        }

        void writeManifest(PackageManifest manifest)
        {
            foreach (SampleEntry sample in manifest.Samples)
            {
                if (sample.StartPackFile != null) sample.StartPart = Path.GetFileName(sample.StartPackFile.Name);
                if (sample.LoopPackFile != null) sample.LoopPart = Path.GetFileName(sample.LoopPackFile.Name);
                if (sample.EndPackFile != null) sample.EndPart = Path.GetFileName(sample.EndPackFile.Name);
            }

            using (System.Xml.XmlWriter writer = System.Xml.XmlWriter.Create(Path.Combine(Path.GetTempPath(), "info.xml"), new System.Xml.XmlWriterSettings { Encoding = Encoding.UTF8, Indent = true }))
            {
                XmlSerializer ser = new XmlSerializer(typeof(PackageManifest));
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add(string.Empty, string.Empty);
                ser.Serialize(writer, manifest, ns);
                writer.Flush();
            }
        }

        void showNotImpl()
        {
            MessageBox.Show(this, "Not implemented yet...", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void packSaveButton_Click(object sender, EventArgs e)
        {
            if (manifest == null)
            {
                MessageBox.Show(this, "Please open a sample package first.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                saveDetails(curEntry);
                manifest.Author = packAuthorTextBox.Text;
                manifest.Website = packWebTextBox.Text;
                manifest.Description = packDescriptionTextBox.Text;
                writeManifest(manifest);

                List<PackageEntry> nonPresentEntries = new List<PackageEntry>(pack.Files);
                foreach (SampleEntry sample in manifest.Samples)
                {
                    if (sample.StartPackFile != null) nonPresentEntries.Remove(sample.StartPackFile);
                    if (sample.LoopPackFile != null) nonPresentEntries.Remove(sample.LoopPackFile);
                    if (sample.EndPackFile != null) nonPresentEntries.Remove(sample.EndPackFile);
                }

                PackageEntry entry = pack.FindEntry("info.xml");
                if (entry == null) pack.CreateEntry(Path.Combine(Path.GetTempPath(), "info.xml"));
                else
                {
                    nonPresentEntries.Remove(entry);
                    entry.Name = Path.Combine(Path.GetTempPath(), "info.xml");
                    entry.Offset = -1;
                }

                foreach (PackageEntry nonPresentEntry in nonPresentEntries)
                {
                    pack.RemoveEntry(nonPresentEntry);
                }

                ProgressForm prog = new ProgressForm(new Action<Action<string, int, int>>(callback => pack.Save(openFileDialog.FileName, callback)));
                prog.ShowDialog(this);
                if (prog.Error == null)
                {
                    itm = null;
                    curEntry = null;
                    samplesListView.Items.Clear();
                    ClearDetails();
                    refreshSamples();
                    MessageBox.Show(this, "Save successful.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(this, "Error while saving: " + prog.Error, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error while saving: " + ex, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (File.Exists(Path.Combine(Path.GetTempPath(), "info.xml"))) File.Delete(Path.Combine(Path.GetTempPath(), "info.xml"));
            }
        }

        private void packDumpButton_Click(object sender, EventArgs e)
        {
            if (pack == null)
            {
                MessageBox.Show(this, "Please open a sample package first.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            folderBrowserDialog1.Description = "Select folder to dump package to";
            if (folderBrowserDialog1.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    Directory.CreateDirectory(folderBrowserDialog1.SelectedPath);
                    ProgressForm prog = new ProgressForm(callback =>
                    {
                        var files = pack.Files;
                        for (int i = 0; i < files.Count; ++i)
                        {
                            PackageEntry entry = files[i];
                            if (callback != null) callback(string.Format("Extracting {0}", entry.Name), i, files.Count);
                            File.WriteAllBytes(Path.Combine(folderBrowserDialog1.SelectedPath, entry.Name), pack.GetFile(entry));
                        }
                        if (callback != null) callback("Complete!", files.Count, files.Count);
                    });
                    prog.ShowDialog(this);
                    if (prog.Error == null)
                    {
                        MessageBox.Show(this, "Extraction successful.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(this, "Error while extracting: " + prog.Error.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Error while extracting: " + ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void packPackButton_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.Description = "Select folder to package";
            if (folderBrowserDialog1.ShowDialog(this) == System.Windows.Forms.DialogResult.OK && saveFileDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                Package newpack = null;
                try
                {
                    newpack = new Package(File.Create(saveFileDialog.FileName));
                    foreach (string path in Directory.GetFiles(folderBrowserDialog1.SelectedPath))
                    {
                        newpack.CreateEntry(path);
                    }

                    ProgressForm prog = new ProgressForm(callback => newpack.Save(saveFileDialog.FileName, callback));
                    prog.ShowDialog(this);
                    if (prog.Error == null)
                    {
                        MessageBox.Show(this, "Packing successful.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(this, "Error while packing: " + prog.Error, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Error while packing: " + ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (newpack != null) newpack.Close();
                }
            }
        }

        private void packOpenButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    openFile();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Couldn't open package: " + ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void openFile()
        {
            if (pack != null) pack.Close();
            samplesListView.Items.Clear();
            ClearDetails();
            packAuthorTextBox.Text = packDescriptionTextBox.Text = packWebTextBox.Text = string.Empty;
            fileNameLabel.Text = string.Empty;
            pack = null;
            manifest = null;
            curEntry = null;

            pack = new Package(File.OpenRead(openFileDialog.FileName));
            pack.Load();
            fileNameLabel.Text = Path.GetFileName(openFileDialog.FileName);

            refreshSamples();
        }

        void refreshSamples()
        {
            manifest = pack.GetManifest();
            if (manifest == null)
            {
                MessageBox.Show(this, "Package does not contain manifest!", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            packAuthorTextBox.Text = manifest.Author;
            packWebTextBox.Text = manifest.Website;
            packDescriptionTextBox.Text = manifest.Description;

            foreach (SampleEntry entry in manifest.Samples)
            {
                samplesListView.Items.Add(new ListViewItem(new string[] { entry.Name, entry.Type, entry.Description }) { Tag = entry });
            }

            samplesListView.SelectedIndices.Clear();
        }

        private void samplesListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pack == null) return;
            saveDetails(curEntry);
            if (samplesListView.SelectedIndices.Count == 0)
            {
                curEntry = null;
                ClearDetails();
            }
            else
            {
                itm = samplesListView.SelectedItems[0];
                curEntry = itm.Tag as SampleEntry;
                loadDetails(curEntry);
            }
        }

        void ClearDetails()
        {
            sampNameTextBox.Text = sampDescriptionTextBox.Text = sampTagsTextBox.Text = string.Empty;
            sampStartLabel.Text = sampLoopLabel.Text = sampEndLabel.Text = "(none)";
            sampTypeComboBox.Text = string.Empty;
        }

        void loadDetails(SampleEntry entry)
        {
            sampNameTextBox.Text = entry.Name;
            sampTypeComboBox.Text = entry.Type;
            sampDescriptionTextBox.Text = entry.Description;
            sampTagsTextBox.Text = entry.TagsString;
            PackageEntry pEntry = entry.StartPackFile;
            if (pEntry == null)
            {
                sampStartLabel.Text = "(none)";
            }
            else
            {
                sampStartLabel.Text = (pEntry.Offset == -1 ? "(disk) " : string.Empty) + pEntry.Name;
            }
            pEntry = entry.LoopPackFile;
            if (pEntry == null)
            {
                sampLoopLabel.Text = "(none)";
            }
            else
            {
                sampLoopLabel.Text = (pEntry.Offset == -1 ? "(disk) " : string.Empty) + pEntry.Name;
            }
            pEntry = entry.EndPackFile;
            if (pEntry == null)
            {
                sampEndLabel.Text = "(none)";
            }
            else
            {
                sampEndLabel.Text = (pEntry.Offset == -1 ? "(disk) " : string.Empty) + pEntry.Name;
            }
        }

        void saveDetails(SampleEntry entry)
        {
            if (entry == null) return;
            entry.Name = sampNameTextBox.Text;
            entry.Type = sampTypeComboBox.Text;
            entry.Description = sampDescriptionTextBox.Text;
            entry.TagsString = sampTagsTextBox.Text;
            itm.SubItems[0].Text = entry.Name;
            itm.SubItems[1].Text = entry.Type;
            itm.SubItems[2].Text = entry.Description;
        }

        private void sampStartReplaceButton_Click(object sender, EventArgs e)
        {
            if (pack == null)
            {
                MessageBox.Show(this, "Please open a sample package first.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (curEntry == null)
            {
                MessageBox.Show(this, "Please select a sample first.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (openFileDialogOgg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                if (curEntry.StartPackFile == null || curEntry.StartPackFile.Offset != -1)
                {
                    curEntry.StartPackFile = pack.CreateEntry(openFileDialogOgg.FileName);
                }
                else
                {
                    curEntry.StartPackFile.Name = openFileDialogOgg.FileName;
                }
                sampStartLabel.Text = "(disk) " + Path.GetFileName(openFileDialogOgg.FileName);
            }
        }

        private void sampLoopReplaceButton_Click(object sender, EventArgs e)
        {
            if (pack == null)
            {
                MessageBox.Show(this, "Please open a sample package first.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (curEntry == null)
            {
                MessageBox.Show(this, "Please select a sample first.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (openFileDialogOgg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                if (curEntry.LoopPackFile == null || curEntry.LoopPackFile.Offset != -1)
                {
                    curEntry.LoopPackFile = pack.CreateEntry(openFileDialogOgg.FileName);
                }
                else
                {
                    curEntry.LoopPackFile.Name = openFileDialogOgg.FileName;
                }
                sampLoopLabel.Text = "(disk) " + Path.GetFileName(openFileDialogOgg.FileName);
            }
        }

        private void sampEndReplaceButton_Click(object sender, EventArgs e)
        {
            if (pack == null)
            {
                MessageBox.Show(this, "Please open a sample package first.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (curEntry == null)
            {
                MessageBox.Show(this, "Please select a sample first.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (openFileDialogOgg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                if (curEntry.EndPackFile == null || curEntry.EndPackFile.Offset != -1)
                {
                    curEntry.EndPackFile = pack.CreateEntry(openFileDialogOgg.FileName);
                }
                else
                {
                    curEntry.EndPackFile.Name = openFileDialogOgg.FileName;
                }
                sampEndLabel.Text = "(disk) " + Path.GetFileName(openFileDialogOgg.FileName);
            }
        }

        private void sampStartRemoveButton_Click(object sender, EventArgs e)
        {
            if (pack == null)
            {
                MessageBox.Show(this, "Please open a sample package first.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (curEntry == null)
            {
                MessageBox.Show(this, "Please select a sample first.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show(this, "Are you sure you want to remove the sample?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                curEntry.StartPackFile = null;
                sampStartLabel.Text = "(none)";
            }
        }

        private void sampLoopRemoveButton_Click(object sender, EventArgs e)
        {
            if (pack == null)
            {
                MessageBox.Show(this, "Please open a sample package first.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (curEntry == null)
            {
                MessageBox.Show(this, "Please select a sample first.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show(this, "Are you sure you want to remove the sample?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                curEntry.LoopPackFile = null;
                sampLoopLabel.Text = "(none)";
            }
        }

        private void sampEndRemoveButton_Click(object sender, EventArgs e)
        {
            if (pack == null)
            {
                MessageBox.Show(this, "Please open a sample package first.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (curEntry == null)
            {
                MessageBox.Show(this, "Please select a sample first.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show(this, "Are you sure you want to remove the sample?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                curEntry.EndPackFile = null;
                sampEndLabel.Text = "(none)";
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (manifest == null)
            {
                MessageBox.Show(this, "Please open a sample package first.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SampleEntry entry = new SampleEntry { Name = "New Sample" };
            manifest.Samples.Add(entry);
            curEntry = entry;
            ListViewItem itm = new ListViewItem(entry.Name) { Tag = entry };
            samplesListView.Items.Add(itm);
            itm.Selected = true;
            itm.EnsureVisible();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (manifest == null)
            {
                MessageBox.Show(this, "Please open a sample package first.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (samplesListView.SelectedItems.Count == 0)
            {
                MessageBox.Show(this, "Please select a sample first.", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show(this, "Are you sure you want to remove this sample?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
            {
                ListViewItem itm = samplesListView.SelectedItems[0];
                manifest.Samples.Remove((SampleEntry)itm.Tag);
                itm.Remove();
            }
        }
    }
}
