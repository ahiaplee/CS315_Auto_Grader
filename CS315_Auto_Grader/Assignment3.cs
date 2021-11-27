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
    class Assignment3 : Assignment
    {
        public Assignment3(MainWindow window)
        {
            this.window = window;
        }

        public override void TestFolders(ListBox FileListBox, TextBox FolderPathTbx, string file_ext)
        {
            base.TestFolders(FileListBox, FolderPathTbx, "*.c");
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

            files = Directory.GetFiles(FolderPathTbx.Text, "*.c", SearchOption.AllDirectories);
            foreach (var file in files)
            {

                FileListBox.Items.Add(file);
            }
        }

        public override void TestAll(ListBox FileListBox, TextBox FolderPathTbx)
        {
            window.AddLog("TEST ALL NO AVAL IN A3");
        }

        public override void TestGrade(string additional_files)
        {
            string output, error;

            Process p = new Process();
            // Redirect the output stream of the child process.
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.Arguments = "/c test.bat";
            p.StartInfo.WorkingDirectory = "A3_Test_Files\\";
            p.Start();
            // Do not wait for the child process to exit before
            // reading to the end of its redirected stream.
            // p.WaitForExit();
            // Read the output stream first and then wait. 
            output = p.StandardOutput.ReadToEnd();
            error = p.StandardError.ReadToEnd();

            p.WaitForExit();

            File.WriteAllText("A3_Test_Files\\stdout.txt", "LOG FOR " + additional_files + '\n' +  output);
            File.WriteAllText("A3_Test_Files\\stderr.txt", "LOG FOR " + additional_files + '\n' + error);

            while (output.Length >= 1)
            {
                int end = output.IndexOf('\n');
                string temp = output.Substring(0, end + 1);
                output = output.Substring(end + 1);
                window.AddLog(temp);
            }

            while (error.Length >= 1)
            {
                int end = error.IndexOf('\n');
                string temp = error.Substring(0, end + 1);
                error = error.Substring(end + 1);
                window.AddLog(temp);
            }
        }

        public override void TestSingle(string item, TextBox FolderPathTbx)
        {
            Cursor.Current = Cursors.WaitCursor;
            window.AddLog("=========================================");
            window.AddLog("Testing A3: " + item + "...");

            string name = Path.GetFileNameWithoutExtension(item);

            if (Directory.Exists(FolderPathTbx.Text + '\\' + name))
            {
                Directory.Delete(FolderPathTbx.Text + '\\' + name, true);
            }

            var files = Directory.GetFiles(FolderPathTbx.Text, "*.c", SearchOption.TopDirectoryOnly);

            foreach (var file in files)
            {
                File.Delete(file);
            }

            files = Directory.GetFiles(FolderPathTbx.Text, "*.pdf", SearchOption.TopDirectoryOnly);

            foreach (var file in files)
            {
                File.Delete(file);
            }

            files = Directory.GetFiles(FolderPathTbx.Text, "*.txt", SearchOption.TopDirectoryOnly);

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

                string source_code = "";
                if (Directory.Exists(FolderPathTbx.Text + '\\' + name))
                {
                    source_code = File.ReadAllText(FolderPathTbx.Text + '\\' + name + "\\opt_poly.c");
                    source_code = source_code.Replace("long degree", "int degree");
                    File.WriteAllText("A3_Test_Files//opt_poly.cpp", source_code);
                }
                else
                {
                    window.AddLog("Top Level folder missing!");
                    source_code = File.ReadAllText(FolderPathTbx.Text + "\\opt_poly.c");
                    source_code = source_code.Replace("long degree", "int degree");
                    File.WriteAllText("A3_Test_Files//opt_poly.cpp", source_code);
                }


                TestGrade(name);
            }
            else
            {
                window.AddLog("Zip file missing!");
            }

            Cursor.Current = Cursors.Default;
        }
    }
}
