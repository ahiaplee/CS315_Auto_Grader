using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;

namespace CS315_Auto_Grader
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        bool Execute_Program(string filename, string args, out string output, out string error)
        {
            // Start the child process.
            Process p = new Process();
            // Redirect the output stream of the child process.
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.FileName = filename;
            p.StartInfo.Arguments = args;
            p.Start();
            // Do not wait for the child process to exit before
            // reading to the end of its redirected stream.
            // p.WaitForExit();
            // Read the output stream first and then wait.
            output = p.StandardOutput.ReadToEnd();
            error = p.StandardError.ReadToEnd();
            p.WaitForExit();


            if (p.ExitCode != 0)
            {
                //Debug.WriteLine("ERROR : " + error);
                return false;
            }

            else
            {
                //Debug.WriteLine("Output : \n" + output);
                return true;
            }
        }

        //private void button1_ClickAsync(object sender, EventArgs e)
        //{
        //    string output, error;

        //    Execute_Program("gcc", "main.c square-root.s", out output, out error);
        //    Execute_Program("a.exe", "", out output, out error);

        //    using (StreamWriter writer = new StreamWriter("myout.txt"))
        //    {
        //        writer.WriteLine(output);
        //    }

        //    Execute_Program("FC", "/w out.txt myout.txt", out output, out error);


        //    if (output.Contains("FC: no differences encountered"))
        //        Debug.Write("PASSED");
        //    else
        //        Debug.Write(output);
        //}

        private void button2_Click(object sender, EventArgs e)
        {
            SearchFolderDialog.ShowDialog();
            FolderPathTbx.Text = SearchFolderDialog.SelectedPath;


            //var files = Directory.GetDirectories
        }

        private void FolderPathTbx_TextChanged(object sender, EventArgs e)
        {
           
        }

        void AddLog(string msg)
        {
            LogListBox.Items.Add(msg);
        }

        void ScanForZip()
        {
            var files = Directory.GetFiles(FolderPathTbx.Text, "*.zip", SearchOption.AllDirectories);
            LogListBox.Items.Add("Scanning " + FolderPathTbx.Text + " for zip files");

            FileListBox.Items.Clear();
            foreach (var file in files)
            {

                FileListBox.Items.Add(Path.GetFileName(file));
            }

            files = Directory.GetFiles(FolderPathTbx.Text, "*.s", SearchOption.AllDirectories);
            foreach (var file in files)
            {

                FileListBox.Items.Add(file);
            }
        }

        private void TestSelectedBtn_Click(object sender, EventArgs e)
        {
            if (FileListBox.SelectedItem == null)
                return;


            string item = (string) FileListBox.SelectedItem;


            TestItem(item);


            return;
            

            string name = Path.GetFileNameWithoutExtension(item);

            if (Directory.Exists(FolderPathTbx.Text + '\\' + name))
            {
                Directory.Delete(FolderPathTbx.Text + '\\' + name, true);
            }


            var files = Directory.GetFiles(FolderPathTbx.Text, "*.s", SearchOption.TopDirectoryOnly);

            foreach (var file in files)
            {
                File.Delete(file);
            }

            ZipFile.ExtractToDirectory(FolderPathTbx.Text +  '\\' + item, FolderPathTbx.Text);


            //Debug.Write(FolderPathTbx.Text + '\\' + Path.GetFileNameWithoutExtension(item));

            if (Directory.Exists(FolderPathTbx.Text + '\\' + name))
            {
                TestGrade(FolderPathTbx.Text + '\\' + name + "\\square-root.s");
            }
            else
                AddLog("Top Level folder missing!");
        }

        void TestGrade(string additional_files)
        {
            string output, error;

            string args = "main.c " + "\"" + additional_files + "\"";

            if (!Execute_Program("gcc", args, out output, out error))
            {
                AddLog("COMPILE ERROR :" + error);
                return;
            }
                
            if(!Execute_Program("a.exe", "", out output, out error))
            {
                AddLog("EXECUTION ERROR :" + error);
                return;
            }
            

            using (StreamWriter writer = new StreamWriter("myout.txt"))
            {
                writer.WriteLine(output);
            }

            Execute_Program("FC", "/w out.txt myout.txt", out output, out error);


            if (output.Contains("FC: no differences encountered"))
                AddLog("PASSED");
            else
                AddLog("FAILED OUTPUT MISMATCH: " + output);


            AddLog("=========================================");
        }

        private void TestAllBtn_Click(object sender, EventArgs e)
        {
            foreach (var entry in FileListBox.Items)
            {
                string item = (string)entry;
                TestItem(item);
            }

            AddLog("Test All Done!");
        }

        void TestItem(string item)
        {
            AddLog("=========================================");
            AddLog("Testing : " + item + "...");

            string name = Path.GetFileNameWithoutExtension(item);

            if (Directory.Exists(FolderPathTbx.Text + '\\' + name))
            {
                Directory.Delete(FolderPathTbx.Text + '\\' + name, true);
            }

            var files = Directory.GetFiles(FolderPathTbx.Text, "*.s", SearchOption.TopDirectoryOnly);

            foreach (var file in files)
            {
                File.Delete(file);
            }

            if(item.Contains(".zip"))
            {
                var actual_file = Directory.GetFiles(FolderPathTbx.Text, item, SearchOption.AllDirectories);

                if (actual_file.Length == 0)
                {
                    AddLog("ERROR finding zip file to extract");
                    return;
                }

                ZipFile.ExtractToDirectory(actual_file[0], FolderPathTbx.Text);

                //Debug.Write(FolderPathTbx.Text + '\\' + Path.GetFileNameWithoutExtension(item));

                if (Directory.Exists(FolderPathTbx.Text + '\\' + name))
                {
                    TestGrade(FolderPathTbx.Text + '\\' + name + "\\square-root.s");
                }
                else
                {
                    AddLog("Top Level folder missing!");
                    
                    TestGrade(FolderPathTbx.Text + '\\' + "square-root.s");
                }
                   
            }
            else
            {
                AddLog("Zip file missing!");
                TestGrade(item);
            }



        }

        private void ClearLogBtn_Click(object sender, EventArgs e)
        {
            LogListBox.Items.Clear();
        }

        private void SaveLogBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.DefaultExt = "txt";
            sfd.AddExtension = true;
            var res = sfd.ShowDialog();

            if(res == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(sfd.FileName))
                {
                    foreach (var entry in LogListBox.Items)
                    {
                        writer.WriteLine((string)entry);
                    }

                }
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            ScanForZip();
        }
    }
}
