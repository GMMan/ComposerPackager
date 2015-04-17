using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComposerPackager.SamplePack;

namespace ComposerPackager
{
    public partial class ProgressForm : Form
    {
        public bool Complete { get; private set; }
        public Exception Error { get; private set; }

        public ProgressForm(Action<Action<string, int, int>> callbackEnabledProc)
        {
            InitializeComponent();
            backgroundWorker1.DoWork += delegate(object sender, DoWorkEventArgs e)
            {
                try
                {
                    callbackEnabledProc(updateProgress);
                }
                catch (Exception ex)
                {
                    Error = ex;
                }
                Complete = true;
                if (InvokeRequired) Invoke(new Action(Close));
                else Close();
            };
        }

        void updateProgress(string text, int progress, int maxProgress)
        {
            if (InvokeRequired) Invoke(new Action(() => updateProgress(text, progress, maxProgress)));
            else
            {
                progressLabel.Text = text;
                if (maxProgress == 0)
                {
                    progressBar1.Style = ProgressBarStyle.Marquee;
                }
                else
                {
                    progressBar1.Style = ProgressBarStyle.Continuous;
                    progressBar1.Maximum = maxProgress;
                    progressBar1.Value = progress;
                }
            }
        }

        private void SaveProgressForm_Shown(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }
    }
}
