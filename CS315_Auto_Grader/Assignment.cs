using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Compression;

namespace CS315_Auto_Grader
{
    abstract class Assignment
    {
        protected MainWindow window;

        public abstract void ScanForZip(ListBox FileListBox, TextBox FolderPathTbx);
        public abstract void TestSingle(string item, TextBox FolderPathTbx);
        public abstract void TestAll(ListBox FileListBox, TextBox FolderPathTbx);
        public abstract void TestGrade(string additional_files);
        public virtual void TestFolders(ListBox FileListBox, TextBox FolderPathTbx, string file_ext)
        {
            Cursor.Current = Cursors.WaitCursor;
            foreach (var entry in FileListBox.Items)
            {
                string item = (string)entry;



                window.AddLog("=========================================");
                window.AddLog("Testing Folders: " + item + "...");

                string name = Path.GetFileNameWithoutExtension(item);

                if (Directory.Exists(FolderPathTbx.Text + '\\' + name))
                {
                    Directory.Delete(FolderPathTbx.Text + '\\' + name, true);
                }

                var files = Directory.GetFiles(FolderPathTbx.Text, file_ext, SearchOption.TopDirectoryOnly);

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

                    if (Directory.Exists(FolderPathTbx.Text + '\\' + name))
                    {

                    }
                    else
                    {
                        window.AddLog("Top Level folder missing!");
                    }


                }
                else
                {
                    window.AddLog("Zip file missing!");
                }



            }

            Cursor.Current = Cursors.Default;
        }
        
    }
}
