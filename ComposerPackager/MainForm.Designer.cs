namespace ComposerPackager
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.fileNameLabel = new System.Windows.Forms.Label();
            this.packPackButton = new System.Windows.Forms.Button();
            this.packDumpButton = new System.Windows.Forms.Button();
            this.packSaveButton = new System.Windows.Forms.Button();
            this.packOpenButton = new System.Windows.Forms.Button();
            this.newPackButton = new System.Windows.Forms.Button();
            this.packDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.packWebTextBox = new System.Windows.Forms.TextBox();
            this.packAuthorTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.samplesListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.sampEndRemoveButton = new System.Windows.Forms.Button();
            this.sampLoopRemoveButton = new System.Windows.Forms.Button();
            this.sampStartRemoveButton = new System.Windows.Forms.Button();
            this.sampEndReplaceButton = new System.Windows.Forms.Button();
            this.sampLoopReplaceButton = new System.Windows.Forms.Button();
            this.sampStartReplaceButton = new System.Windows.Forms.Button();
            this.sampEndLabel = new System.Windows.Forms.Label();
            this.sampLoopLabel = new System.Windows.Forms.Label();
            this.sampStartLabel = new System.Windows.Forms.Label();
            this.sampDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.sampTagsTextBox = new System.Windows.Forms.TextBox();
            this.sampTypeComboBox = new System.Windows.Forms.ComboBox();
            this.sampNameTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.addButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.previewButton = new System.Windows.Forms.Button();
            this.openFileDialogOgg = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.fileNameLabel);
            this.groupBox1.Controls.Add(this.packPackButton);
            this.groupBox1.Controls.Add(this.packDumpButton);
            this.groupBox1.Controls.Add(this.packSaveButton);
            this.groupBox1.Controls.Add(this.packOpenButton);
            this.groupBox1.Controls.Add(this.newPackButton);
            this.groupBox1.Controls.Add(this.packDescriptionTextBox);
            this.groupBox1.Controls.Add(this.packWebTextBox);
            this.groupBox1.Controls.Add(this.packAuthorTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(563, 155);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sample Package";
            // 
            // fileNameLabel
            // 
            this.fileNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileNameLabel.Location = new System.Drawing.Point(330, 24);
            this.fileNameLabel.Name = "fileNameLabel";
            this.fileNameLabel.Size = new System.Drawing.Size(146, 21);
            this.fileNameLabel.TabIndex = 4;
            // 
            // packPackButton
            // 
            this.packPackButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.packPackButton.Location = new System.Drawing.Point(482, 19);
            this.packPackButton.Name = "packPackButton";
            this.packPackButton.Size = new System.Drawing.Size(75, 23);
            this.packPackButton.TabIndex = 5;
            this.packPackButton.Text = "Pack…";
            this.packPackButton.UseVisualStyleBackColor = true;
            this.packPackButton.Click += new System.EventHandler(this.packPackButton_Click);
            // 
            // packDumpButton
            // 
            this.packDumpButton.Location = new System.Drawing.Point(249, 19);
            this.packDumpButton.Name = "packDumpButton";
            this.packDumpButton.Size = new System.Drawing.Size(75, 23);
            this.packDumpButton.TabIndex = 3;
            this.packDumpButton.Text = "Dump…";
            this.packDumpButton.UseVisualStyleBackColor = true;
            this.packDumpButton.Click += new System.EventHandler(this.packDumpButton_Click);
            // 
            // packSaveButton
            // 
            this.packSaveButton.Location = new System.Drawing.Point(168, 19);
            this.packSaveButton.Name = "packSaveButton";
            this.packSaveButton.Size = new System.Drawing.Size(75, 23);
            this.packSaveButton.TabIndex = 2;
            this.packSaveButton.Text = "Save";
            this.packSaveButton.UseVisualStyleBackColor = true;
            this.packSaveButton.Click += new System.EventHandler(this.packSaveButton_Click);
            // 
            // packOpenButton
            // 
            this.packOpenButton.Location = new System.Drawing.Point(87, 19);
            this.packOpenButton.Name = "packOpenButton";
            this.packOpenButton.Size = new System.Drawing.Size(75, 23);
            this.packOpenButton.TabIndex = 1;
            this.packOpenButton.Text = "Open…";
            this.packOpenButton.UseVisualStyleBackColor = true;
            this.packOpenButton.Click += new System.EventHandler(this.packOpenButton_Click);
            // 
            // newPackButton
            // 
            this.newPackButton.Location = new System.Drawing.Point(6, 19);
            this.newPackButton.Name = "newPackButton";
            this.newPackButton.Size = new System.Drawing.Size(75, 23);
            this.newPackButton.TabIndex = 0;
            this.newPackButton.Text = "New…";
            this.newPackButton.UseVisualStyleBackColor = true;
            this.newPackButton.Click += new System.EventHandler(this.newPackButton_Click);
            // 
            // packDescriptionTextBox
            // 
            this.packDescriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.packDescriptionTextBox.Location = new System.Drawing.Point(72, 100);
            this.packDescriptionTextBox.Multiline = true;
            this.packDescriptionTextBox.Name = "packDescriptionTextBox";
            this.packDescriptionTextBox.Size = new System.Drawing.Size(485, 45);
            this.packDescriptionTextBox.TabIndex = 11;
            // 
            // packWebTextBox
            // 
            this.packWebTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.packWebTextBox.Location = new System.Drawing.Point(72, 74);
            this.packWebTextBox.Name = "packWebTextBox";
            this.packWebTextBox.Size = new System.Drawing.Size(485, 20);
            this.packWebTextBox.TabIndex = 9;
            // 
            // packAuthorTextBox
            // 
            this.packAuthorTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.packAuthorTextBox.Location = new System.Drawing.Point(72, 48);
            this.packAuthorTextBox.Name = "packAuthorTextBox";
            this.packAuthorTextBox.Size = new System.Drawing.Size(485, 20);
            this.packAuthorTextBox.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Description";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Website:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Author:";
            // 
            // samplesListView
            // 
            this.samplesListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.samplesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.samplesListView.FullRowSelect = true;
            this.samplesListView.HideSelection = false;
            this.samplesListView.Location = new System.Drawing.Point(12, 173);
            this.samplesListView.MultiSelect = false;
            this.samplesListView.Name = "samplesListView";
            this.samplesListView.Size = new System.Drawing.Size(563, 130);
            this.samplesListView.TabIndex = 1;
            this.samplesListView.UseCompatibleStateImageBehavior = false;
            this.samplesListView.View = System.Windows.Forms.View.Details;
            this.samplesListView.SelectedIndexChanged += new System.EventHandler(this.samplesListView_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 169;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Type";
            this.columnHeader2.Width = 88;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Description";
            this.columnHeader3.Width = 293;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.sampEndRemoveButton);
            this.groupBox2.Controls.Add(this.sampLoopRemoveButton);
            this.groupBox2.Controls.Add(this.sampStartRemoveButton);
            this.groupBox2.Controls.Add(this.sampEndReplaceButton);
            this.groupBox2.Controls.Add(this.sampLoopReplaceButton);
            this.groupBox2.Controls.Add(this.sampStartReplaceButton);
            this.groupBox2.Controls.Add(this.sampEndLabel);
            this.groupBox2.Controls.Add(this.sampLoopLabel);
            this.groupBox2.Controls.Add(this.sampStartLabel);
            this.groupBox2.Controls.Add(this.sampDescriptionTextBox);
            this.groupBox2.Controls.Add(this.sampTagsTextBox);
            this.groupBox2.Controls.Add(this.sampTypeComboBox);
            this.groupBox2.Controls.Add(this.sampNameTextBox);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 338);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(563, 155);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sample Details";
            // 
            // sampEndRemoveButton
            // 
            this.sampEndRemoveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sampEndRemoveButton.Location = new System.Drawing.Point(371, 124);
            this.sampEndRemoveButton.Name = "sampEndRemoveButton";
            this.sampEndRemoveButton.Size = new System.Drawing.Size(75, 23);
            this.sampEndRemoveButton.TabIndex = 19;
            this.sampEndRemoveButton.Text = "Remove";
            this.sampEndRemoveButton.UseVisualStyleBackColor = true;
            this.sampEndRemoveButton.Click += new System.EventHandler(this.sampEndRemoveButton_Click);
            // 
            // sampLoopRemoveButton
            // 
            this.sampLoopRemoveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sampLoopRemoveButton.Location = new System.Drawing.Point(371, 82);
            this.sampLoopRemoveButton.Name = "sampLoopRemoveButton";
            this.sampLoopRemoveButton.Size = new System.Drawing.Size(75, 23);
            this.sampLoopRemoveButton.TabIndex = 15;
            this.sampLoopRemoveButton.Text = "Remove";
            this.sampLoopRemoveButton.UseVisualStyleBackColor = true;
            this.sampLoopRemoveButton.Click += new System.EventHandler(this.sampLoopRemoveButton_Click);
            // 
            // sampStartRemoveButton
            // 
            this.sampStartRemoveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sampStartRemoveButton.Location = new System.Drawing.Point(371, 40);
            this.sampStartRemoveButton.Name = "sampStartRemoveButton";
            this.sampStartRemoveButton.Size = new System.Drawing.Size(75, 23);
            this.sampStartRemoveButton.TabIndex = 11;
            this.sampStartRemoveButton.Text = "Remove";
            this.sampStartRemoveButton.UseVisualStyleBackColor = true;
            this.sampStartRemoveButton.Click += new System.EventHandler(this.sampStartRemoveButton_Click);
            // 
            // sampEndReplaceButton
            // 
            this.sampEndReplaceButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sampEndReplaceButton.Location = new System.Drawing.Point(290, 124);
            this.sampEndReplaceButton.Name = "sampEndReplaceButton";
            this.sampEndReplaceButton.Size = new System.Drawing.Size(75, 23);
            this.sampEndReplaceButton.TabIndex = 18;
            this.sampEndReplaceButton.Text = "Replace…";
            this.sampEndReplaceButton.UseVisualStyleBackColor = true;
            this.sampEndReplaceButton.Click += new System.EventHandler(this.sampEndReplaceButton_Click);
            // 
            // sampLoopReplaceButton
            // 
            this.sampLoopReplaceButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sampLoopReplaceButton.Location = new System.Drawing.Point(290, 82);
            this.sampLoopReplaceButton.Name = "sampLoopReplaceButton";
            this.sampLoopReplaceButton.Size = new System.Drawing.Size(75, 23);
            this.sampLoopReplaceButton.TabIndex = 14;
            this.sampLoopReplaceButton.Text = "Replace…";
            this.sampLoopReplaceButton.UseVisualStyleBackColor = true;
            this.sampLoopReplaceButton.Click += new System.EventHandler(this.sampLoopReplaceButton_Click);
            // 
            // sampStartReplaceButton
            // 
            this.sampStartReplaceButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sampStartReplaceButton.Location = new System.Drawing.Point(290, 40);
            this.sampStartReplaceButton.Name = "sampStartReplaceButton";
            this.sampStartReplaceButton.Size = new System.Drawing.Size(75, 23);
            this.sampStartReplaceButton.TabIndex = 10;
            this.sampStartReplaceButton.Text = "Replace…";
            this.sampStartReplaceButton.UseVisualStyleBackColor = true;
            this.sampStartReplaceButton.Click += new System.EventHandler(this.sampStartReplaceButton_Click);
            // 
            // sampEndLabel
            // 
            this.sampEndLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sampEndLabel.AutoEllipsis = true;
            this.sampEndLabel.Location = new System.Drawing.Point(360, 108);
            this.sampEndLabel.Name = "sampEndLabel";
            this.sampEndLabel.Size = new System.Drawing.Size(197, 13);
            this.sampEndLabel.TabIndex = 17;
            this.sampEndLabel.Text = "(none)";
            // 
            // sampLoopLabel
            // 
            this.sampLoopLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sampLoopLabel.AutoEllipsis = true;
            this.sampLoopLabel.Location = new System.Drawing.Point(365, 66);
            this.sampLoopLabel.Name = "sampLoopLabel";
            this.sampLoopLabel.Size = new System.Drawing.Size(192, 13);
            this.sampLoopLabel.TabIndex = 13;
            this.sampLoopLabel.Text = "(none)";
            // 
            // sampStartLabel
            // 
            this.sampStartLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sampStartLabel.AutoEllipsis = true;
            this.sampStartLabel.Location = new System.Drawing.Point(363, 24);
            this.sampStartLabel.Name = "sampStartLabel";
            this.sampStartLabel.Size = new System.Drawing.Size(194, 13);
            this.sampStartLabel.TabIndex = 9;
            this.sampStartLabel.Text = "(none)";
            // 
            // sampDescriptionTextBox
            // 
            this.sampDescriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sampDescriptionTextBox.Location = new System.Drawing.Point(75, 72);
            this.sampDescriptionTextBox.Multiline = true;
            this.sampDescriptionTextBox.Name = "sampDescriptionTextBox";
            this.sampDescriptionTextBox.Size = new System.Drawing.Size(206, 51);
            this.sampDescriptionTextBox.TabIndex = 5;
            // 
            // sampTagsTextBox
            // 
            this.sampTagsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sampTagsTextBox.Location = new System.Drawing.Point(75, 129);
            this.sampTagsTextBox.Name = "sampTagsTextBox";
            this.sampTagsTextBox.Size = new System.Drawing.Size(206, 20);
            this.sampTagsTextBox.TabIndex = 7;
            // 
            // sampTypeComboBox
            // 
            this.sampTypeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sampTypeComboBox.FormattingEnabled = true;
            this.sampTypeComboBox.Items.AddRange(new object[] {
            "ambient",
            "melody",
            "bass",
            "sequence",
            "effect",
            "harmony",
            "rhythm"});
            this.sampTypeComboBox.Location = new System.Drawing.Point(75, 45);
            this.sampTypeComboBox.Name = "sampTypeComboBox";
            this.sampTypeComboBox.Size = new System.Drawing.Size(206, 21);
            this.sampTypeComboBox.TabIndex = 3;
            // 
            // sampNameTextBox
            // 
            this.sampNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sampNameTextBox.Location = new System.Drawing.Point(75, 19);
            this.sampNameTextBox.Name = "sampNameTextBox";
            this.sampNameTextBox.Size = new System.Drawing.Size(206, 20);
            this.sampNameTextBox.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 132);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "Tags:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 75);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Description:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Type:";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(287, 108);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "End Sample:";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(287, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Loop Sample:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(287, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Start Sample:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Name:";
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Circuits Composer Sample Packages|*.spack";
            // 
            // addButton
            // 
            this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addButton.Location = new System.Drawing.Point(12, 309);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 2;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.removeButton.Location = new System.Drawing.Point(93, 309);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(75, 23);
            this.removeButton.TabIndex = 3;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // previewButton
            // 
            this.previewButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.previewButton.Enabled = false;
            this.previewButton.Location = new System.Drawing.Point(174, 309);
            this.previewButton.Name = "previewButton";
            this.previewButton.Size = new System.Drawing.Size(75, 23);
            this.previewButton.TabIndex = 4;
            this.previewButton.Text = "Preview";
            this.previewButton.UseVisualStyleBackColor = true;
            // 
            // openFileDialogOgg
            // 
            this.openFileDialogOgg.Filter = "Ogg Vorbis Audio|*.ogg";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Circuits Composer Sample Packages|*.spack";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 505);
            this.Controls.Add(this.previewButton);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.samplesListView);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Circuits Composer Packager";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox packDescriptionTextBox;
        private System.Windows.Forms.TextBox packWebTextBox;
        private System.Windows.Forms.TextBox packAuthorTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView samplesListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button packPackButton;
        private System.Windows.Forms.Button packDumpButton;
        private System.Windows.Forms.Button packSaveButton;
        private System.Windows.Forms.Button packOpenButton;
        private System.Windows.Forms.Button newPackButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button sampEndRemoveButton;
        private System.Windows.Forms.Button sampLoopRemoveButton;
        private System.Windows.Forms.Button sampStartRemoveButton;
        private System.Windows.Forms.Button sampEndReplaceButton;
        private System.Windows.Forms.Button sampLoopReplaceButton;
        private System.Windows.Forms.Button sampStartReplaceButton;
        private System.Windows.Forms.Label sampEndLabel;
        private System.Windows.Forms.Label sampLoopLabel;
        private System.Windows.Forms.Label sampStartLabel;
        private System.Windows.Forms.TextBox sampDescriptionTextBox;
        private System.Windows.Forms.TextBox sampTagsTextBox;
        private System.Windows.Forms.ComboBox sampTypeComboBox;
        private System.Windows.Forms.TextBox sampNameTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button previewButton;
        private System.Windows.Forms.Label fileNameLabel;
        private System.Windows.Forms.OpenFileDialog openFileDialogOgg;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;

    }
}

