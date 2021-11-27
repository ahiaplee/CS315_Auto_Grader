
namespace CS315_Auto_Grader
{
    partial class MainWindow
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
            this.SearchFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.BrowseBtn = new System.Windows.Forms.Button();
            this.FolderPathTbx = new System.Windows.Forms.TextBox();
            this.FileListBox = new System.Windows.Forms.ListBox();
            this.LogListBox = new System.Windows.Forms.ListBox();
            this.TestSelectedBtn = new System.Windows.Forms.Button();
            this.TestAllBtn = new System.Windows.Forms.Button();
            this.ClearLogBtn = new System.Windows.Forms.Button();
            this.SaveLogBtn = new System.Windows.Forms.Button();
            this.UpperPanel = new System.Windows.Forms.Panel();
            this.LowerPanel = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.AssignmentSel = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.UpperPanel.SuspendLayout();
            this.LowerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // BrowseBtn
            // 
            this.BrowseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BrowseBtn.Location = new System.Drawing.Point(610, 6);
            this.BrowseBtn.Name = "BrowseBtn";
            this.BrowseBtn.Size = new System.Drawing.Size(49, 23);
            this.BrowseBtn.TabIndex = 1;
            this.BrowseBtn.Text = "...";
            this.BrowseBtn.UseVisualStyleBackColor = true;
            this.BrowseBtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // FolderPathTbx
            // 
            this.FolderPathTbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FolderPathTbx.Location = new System.Drawing.Point(3, 6);
            this.FolderPathTbx.Name = "FolderPathTbx";
            this.FolderPathTbx.Size = new System.Drawing.Size(601, 20);
            this.FolderPathTbx.TabIndex = 2;
            this.FolderPathTbx.TextChanged += new System.EventHandler(this.FolderPathTbx_TextChanged);
            // 
            // FileListBox
            // 
            this.FileListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FileListBox.FormattingEnabled = true;
            this.FileListBox.Location = new System.Drawing.Point(2, 32);
            this.FileListBox.Name = "FileListBox";
            this.FileListBox.Size = new System.Drawing.Size(602, 173);
            this.FileListBox.Sorted = true;
            this.FileListBox.TabIndex = 3;
            // 
            // LogListBox
            // 
            this.LogListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogListBox.FormattingEnabled = true;
            this.LogListBox.Location = new System.Drawing.Point(3, 3);
            this.LogListBox.Name = "LogListBox";
            this.LogListBox.Size = new System.Drawing.Size(734, 160);
            this.LogListBox.TabIndex = 4;
            // 
            // TestSelectedBtn
            // 
            this.TestSelectedBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TestSelectedBtn.Location = new System.Drawing.Point(610, 35);
            this.TestSelectedBtn.Name = "TestSelectedBtn";
            this.TestSelectedBtn.Size = new System.Drawing.Size(122, 23);
            this.TestSelectedBtn.TabIndex = 5;
            this.TestSelectedBtn.Text = "Test Selected";
            this.TestSelectedBtn.UseVisualStyleBackColor = true;
            this.TestSelectedBtn.Click += new System.EventHandler(this.TestSelectedBtn_Click);
            // 
            // TestAllBtn
            // 
            this.TestAllBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TestAllBtn.Location = new System.Drawing.Point(610, 64);
            this.TestAllBtn.Name = "TestAllBtn";
            this.TestAllBtn.Size = new System.Drawing.Size(122, 23);
            this.TestAllBtn.TabIndex = 6;
            this.TestAllBtn.Text = "Test All";
            this.TestAllBtn.UseVisualStyleBackColor = true;
            this.TestAllBtn.Click += new System.EventHandler(this.TestAllBtn_Click);
            // 
            // ClearLogBtn
            // 
            this.ClearLogBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ClearLogBtn.Location = new System.Drawing.Point(662, 167);
            this.ClearLogBtn.Name = "ClearLogBtn";
            this.ClearLogBtn.Size = new System.Drawing.Size(75, 23);
            this.ClearLogBtn.TabIndex = 7;
            this.ClearLogBtn.Text = "Clear Log";
            this.ClearLogBtn.UseVisualStyleBackColor = true;
            this.ClearLogBtn.Click += new System.EventHandler(this.ClearLogBtn_Click);
            // 
            // SaveLogBtn
            // 
            this.SaveLogBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveLogBtn.Location = new System.Drawing.Point(584, 167);
            this.SaveLogBtn.Name = "SaveLogBtn";
            this.SaveLogBtn.Size = new System.Drawing.Size(75, 23);
            this.SaveLogBtn.TabIndex = 8;
            this.SaveLogBtn.Text = "Save Log";
            this.SaveLogBtn.UseVisualStyleBackColor = true;
            this.SaveLogBtn.Click += new System.EventHandler(this.SaveLogBtn_Click);
            // 
            // UpperPanel
            // 
            this.UpperPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UpperPanel.Controls.Add(this.LogListBox);
            this.UpperPanel.Controls.Add(this.ClearLogBtn);
            this.UpperPanel.Controls.Add(this.SaveLogBtn);
            this.UpperPanel.Location = new System.Drawing.Point(13, 233);
            this.UpperPanel.Name = "UpperPanel";
            this.UpperPanel.Size = new System.Drawing.Size(740, 193);
            this.UpperPanel.TabIndex = 9;
            // 
            // LowerPanel
            // 
            this.LowerPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LowerPanel.Controls.Add(this.button2);
            this.LowerPanel.Controls.Add(this.label1);
            this.LowerPanel.Controls.Add(this.AssignmentSel);
            this.LowerPanel.Controls.Add(this.button1);
            this.LowerPanel.Controls.Add(this.FileListBox);
            this.LowerPanel.Controls.Add(this.FolderPathTbx);
            this.LowerPanel.Controls.Add(this.TestAllBtn);
            this.LowerPanel.Controls.Add(this.BrowseBtn);
            this.LowerPanel.Controls.Add(this.TestSelectedBtn);
            this.LowerPanel.Location = new System.Drawing.Point(13, 12);
            this.LowerPanel.Name = "LowerPanel";
            this.LowerPanel.Size = new System.Drawing.Size(740, 215);
            this.LowerPanel.TabIndex = 10;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(610, 93);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Check Folders";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(623, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Select Assignment";
            // 
            // AssignmentSel
            // 
            this.AssignmentSel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AssignmentSel.FormattingEnabled = true;
            this.AssignmentSel.Items.AddRange(new object[] {
            "Assignment 1",
            "Assignment 2",
            "Assignment 3",
            "Assignment 4"});
            this.AssignmentSel.Location = new System.Drawing.Point(610, 145);
            this.AssignmentSel.Name = "AssignmentSel";
            this.AssignmentSel.Size = new System.Drawing.Size(121, 21);
            this.AssignmentSel.TabIndex = 8;
            this.AssignmentSel.SelectedIndexChanged += new System.EventHandler(this.AssignmentSel_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(665, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(67, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Refresh";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 450);
            this.Controls.Add(this.LowerPanel);
            this.Controls.Add(this.UpperPanel);
            this.Name = "MainWindow";
            this.Text = "CS315 A1 Auto Grader";
            this.UpperPanel.ResumeLayout(false);
            this.LowerPanel.ResumeLayout(false);
            this.LowerPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FolderBrowserDialog SearchFolderDialog;
        private System.Windows.Forms.Button BrowseBtn;
        private System.Windows.Forms.TextBox FolderPathTbx;
        private System.Windows.Forms.ListBox FileListBox;
        private System.Windows.Forms.ListBox LogListBox;
        private System.Windows.Forms.Button TestSelectedBtn;
        private System.Windows.Forms.Button TestAllBtn;
        private System.Windows.Forms.Button ClearLogBtn;
        private System.Windows.Forms.Button SaveLogBtn;
        private System.Windows.Forms.Panel UpperPanel;
        private System.Windows.Forms.Panel LowerPanel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox AssignmentSel;

        private Assignment currentAssignment;
        private Assignment1 A1;
        private Assignment2 A2;
        private Assignment3 A3;
        private Assignment4 A4;
        private System.Windows.Forms.Button button2;
    }
}

