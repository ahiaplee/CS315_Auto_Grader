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
    class Assignment2 : Assignment
    {
        public Assignment2(MainWindow window)
        {
            this.window = window;
        }

        public override void TestFolders(ListBox FileListBox, TextBox FolderPathTbx, string file_ext)
        {
            base.TestFolders(FileListBox, FolderPathTbx, "*.cpp");
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

            files = Directory.GetFiles(FolderPathTbx.Text, "*.cpp", SearchOption.AllDirectories);
            foreach (var file in files)
            {

                FileListBox.Items.Add(file);
            }
        }

        public override void TestAll(ListBox FileListBox, TextBox FolderPathTbx)
        {
            window.AddLog("TEST ALL NO AVAL IN A2");
            //foreach (var entry in FileListBox.Items)
            //{
            //    string item = (string)entry;
            //    this.TestSingle(item, FolderPathTbx);
            //}

            //window.AddLog("Test All Done!");
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
            p.StartInfo.Arguments = "/c A2_Test.bat";
            p.StartInfo.WorkingDirectory = "A2_Test_Files\\";
            p.Start();
            // Do not wait for the child process to exit before
            // reading to the end of its redirected stream.
            // p.WaitForExit();
            // Read the output stream first and then wait. 
            output = p.StandardOutput.ReadToEnd();
            error = p.StandardError.ReadToEnd();

            p.WaitForExit();

            File.WriteAllText("A2_Test_Files\\stdout.txt", "LOG FOR " + additional_files + '\n' +  output);
            File.WriteAllText("A2_Test_Files\\stderr.txt", "LOG FOR " + additional_files + '\n' + error);

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


          

            //window.AddLog(output);
            //window.AddLog(error);

            //throw new NotImplementedException();
        }

        public override void TestSingle(string item, TextBox FolderPathTbx)
        {
            Cursor.Current = Cursors.WaitCursor;
            window.AddLog("=========================================");
            window.AddLog("Testing A2: " + item + "...");

            string name = Path.GetFileNameWithoutExtension(item);

            if (Directory.Exists(FolderPathTbx.Text + '\\' + name))
            {
                Directory.Delete(FolderPathTbx.Text + '\\' + name, true);
            }

            var files = Directory.GetFiles(FolderPathTbx.Text, "*.cpp", SearchOption.TopDirectoryOnly);

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

                /*
                    basic_sobel_edge_detection, avx_sobel_edge_detection,
                    basic_kirsch_operator, avx_kirsch_edge_detection
                */

                string source_code = "";
                if (Directory.Exists(FolderPathTbx.Text + '\\' + name))
                {
                    //TestGrade(FolderPathTbx.Text + '\\' + name + "\\square-root.s");
                    source_code = File.ReadAllText(FolderPathTbx.Text + '\\' + name + "\\edge.cpp");


                    
                    //source_code.Replace("avx_kirsch_edge_detection", "avx_kirsch_edge_detection");
                }
                else
                {
                    window.AddLog("Top Level folder missing!");

                    //TestGrade(FolderPathTbx.Text + '\\' + "square-root.s");
                    source_code = File.ReadAllText(FolderPathTbx.Text + '\\' + "edge.cpp");
                }

                if (source_code.Length > 0)
                {
                    if (File.Exists("A2_Test_Files//edge.cpp"))
                        File.Delete("A2_Test_Files//edge.cpp");

                    source_code = source_code.Replace("int main", "int main_old");
                    source_code = source_code.Replace("basic_sobel_edge_detection", "basic_sobel_edge_detection_old");
                    source_code = source_code.Replace("basic_kirsch_operator", "basic_kirsch_operator_old");
                    source_code = source_code.Replace("avx_sobel_edge_detection", "avx_sobel_edge_detection_old");

                    File.WriteAllText("A2_Test_Files//edge.cpp", source_code);
                }

                TestGrade(name);
            }
            else
            {
                window.AddLog("Zip file missing!");

                string source_code = "";
                source_code = source_code.Replace("int main", "int main_old");
                source_code = source_code.Replace("basic_sobel_edge_detection", "basic_sobel_edge_detection_old");
                source_code = source_code.Replace("basic_kirsch_operator", "basic_kirsch_operator_old");
                source_code = source_code.Replace("avx_sobel_edge_detection", "avx_sobel_edge_detection_old");
                File.WriteAllText("A2_Test_Files//edge.cpp", source_code);

                //TestGrade(item);
                TestGrade(name);
            }

            Cursor.Current = Cursors.Default;
        }
    }
}
