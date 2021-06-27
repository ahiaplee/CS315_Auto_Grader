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
    class Assignment1 : Assignment
    {
        public Assignment1(MainWindow window)
        {
            this.window = window;
        }

        public override void TestFolders(ListBox FileListBox, TextBox FolderPathTbx, string file_ext)
        {
            base.TestFolders(FileListBox, FolderPathTbx, "*.s");
        }

        public override void ScanForZip(ListBox FileListBox, TextBox FolderPathTbx) 
        {
            var files = Directory.GetFiles(FolderPathTbx.Text, "*.zip", SearchOption.AllDirectories);
            window.AddLog("Scanning " + FolderPathTbx.Text + " for zip files");

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

        public override void TestAll(ListBox FileListBox, TextBox FolderPathTbx)
        {
            foreach (var entry in FileListBox.Items)
            {
                string item = (string)entry;
                this.TestSingle(item, FolderPathTbx);
            }

            window.AddLog("Test All Done!");
        }

        public override void TestGrade(string additional_files)
        {
            string output, error;

            string args = "main.c " + "\"" + additional_files + "\"";

            if (!window.Execute_Program("gcc", args, out output, out error))
            {
                window.AddLog("COMPILE ERROR :" + error);
                return;
            }

            if (!window.Execute_Program("a.exe", "", out output, out error))
            {
                window.AddLog("EXECUTION ERROR :" + error);
                return;
            }


            using (StreamWriter writer = new StreamWriter("myout.txt"))
            {
                writer.WriteLine(output);
            }

            window.Execute_Program("FC", "/w out.txt myout.txt", out output, out error);


            if (output.Contains("FC: no differences encountered"))
                window.AddLog("PASSED");
            else
                window.AddLog("FAILED OUTPUT MISMATCH: " + output);


            window.AddLog("=========================================");
        }

        public override void TestSingle(string item, TextBox FolderPathTbx)
        {
            window.AddLog("=========================================");
            window.AddLog("Testing A1: " + item + "...");

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

            if (item.Contains(".zip"))
            {
                var actual_file = Directory.GetFiles(FolderPathTbx.Text, item, SearchOption.AllDirectories);

                if (actual_file.Length == 0)
                {
                    window.AddLog("ERROR finding zip file to extract");
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
                    window.AddLog("Top Level folder missing!");

                    TestGrade(FolderPathTbx.Text + '\\' + "square-root.s");
                }

            }
            else
            {
                window.AddLog("Zip file missing!");
                TestGrade(item);
            }
        }
    }
}
