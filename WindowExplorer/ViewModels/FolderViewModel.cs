using Caliburn.Micro;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows;
using WindowExplorer.Models;

namespace WindowExplorer.ViewModels
{
    public class FolderViewModel : Screen
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private BindableCollection<WindowExplorerModel> _folder = new BindableCollection<WindowExplorerModel>();
        private WindowExplorerModel _selectedFolder;

        public BindableCollection<WindowExplorerModel> Folder
        {
            get { return _folder; }
            set { _folder = value; }
        }

        public FolderViewModel()
        {
            GetFoldersRelatedToDrive(Global.Type,Global.FullPath);
        }

        public WindowExplorerModel SelectedFolder
        {
            get { return _selectedFolder; }
            set
            {
                _selectedFolder = value;
                OnPropertyChanged(_selectedFolder);
            }
        }

        protected void OnPropertyChanged(WindowExplorerModel selectedItem)
        {
            if (selectedItem != null)
            {
                Global.FullPath = selectedItem.FullPath;
                Global.Type = selectedItem.Type;

                ((WindowExplorerViewModel)Parent).RefreshFileScreen();
            }
        }

        private void GetFoldersRelatedToDrive(string type, string fullpath)
        {
            Folder = new BindableCollection<WindowExplorerModel>();
            if(type=="Drive")
            {
                try
                {
                    foreach (var folder in Directory.GetDirectories(fullpath))
                    {
                        Folder.Add(new WindowExplorerModel { FullPath = folder, Name = folder.Substring(folder.LastIndexOf(@"\") + 1), Type = "Folder" });
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }            
        }
    }
}
