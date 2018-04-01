using Caliburn.Micro;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows;
using WindowExplorer.Models;

namespace WindowExplorer.ViewModels
{
    public class FileViewModel : Screen
    {
        private BindableCollection<WindowExplorerModel> _file = new BindableCollection<WindowExplorerModel>();

        public BindableCollection<WindowExplorerModel> File
        {
            get { return _file; }
            set { _file = value; }
        }

        public FileViewModel()
        {
            GetFilesRelatedToFolder(Global.Type, Global.FullPath);
        }

        private void GetFilesRelatedToFolder(string type, string fullpath)
        {
            File = new BindableCollection<WindowExplorerModel>();
            if (type == "Folder")
            {
                try
                {
                    foreach (var file in Directory.GetFiles(fullpath))
                    {
                        File.Add(new WindowExplorerModel { FullPath = file, Name = file.Substring(file.LastIndexOf(@"\") + 1), Type = "File" });
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }
    }
}
