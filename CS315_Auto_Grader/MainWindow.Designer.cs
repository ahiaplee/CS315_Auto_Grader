﻿
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
            this.UpperPanel.SuspendLayout();
            this.LowerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // BrowseBtn
            // 
            this.BrowseBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BrowseBtn.Location = new System.Drawing.Point(512, 6);
            this.BrowseBtn.Name = "BrowseBtn";
            this.BrowseBtn.Size = new System.Drawing.Size(122, 23);
            this.BrowseBtn.TabIndex = 1;
            this.BrowseBtn.Text = "Browse";
            this.BrowseBtn.UseVisualStyleBackColor = true;
            this.BrowseBtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // FolderPathTbx
            // 
            this.FolderPathTbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FolderPathTbx.Location = new System.Drawing.Point(3, 6);
            this.FolderPathTbx.Name = "FolderPathTbx";
            this.FolderPathTbx.Size = new System.Drawing.Size(503, 20);
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
            this.FileListBox.Size = new System.Drawing.Size(504, 173);
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
            this.LogListBox.Size = new System.Drawing.Size(636, 160);
            this.LogListBox.TabIndex = 4;
            // 
            // TestSelectedBtn
            // 
            this.TestSelectedBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TestSelectedBtn.Location = new System.Drawing.Point(512, 35);
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
            this.TestAllBtn.Location = new System.Drawing.Point(512, 64);
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
            this.ClearLogBtn.Location = new System.Drawing.Point(564, 167);
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
            this.SaveLogBtn.Location = new System.Drawing.Point(486, 167);
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
            this.UpperPanel.Size = new System.Drawing.Size(642, 193);
            this.UpperPanel.TabIndex = 9;
            // 
            // LowerPanel
            // 
            this.LowerPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LowerPanel.Controls.Add(this.FileListBox);
            this.LowerPanel.Controls.Add(this.FolderPathTbx);
            this.LowerPanel.Controls.Add(this.TestAllBtn);
            this.LowerPanel.Controls.Add(this.BrowseBtn);
            this.LowerPanel.Controls.Add(this.TestSelectedBtn);
            this.LowerPanel.Location = new System.Drawing.Point(13, 12);
            this.LowerPanel.Name = "LowerPanel";
            this.LowerPanel.Size = new System.Drawing.Size(642, 215);
            this.LowerPanel.TabIndex = 10;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 450);
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
    }
}

