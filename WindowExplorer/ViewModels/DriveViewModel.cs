using Caliburn.Micro;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows;
using WindowExplorer.Models;

namespace WindowExplorer.ViewModels
{
    public class DriveViewModel : Screen
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private BindableCollection<WindowExplorerModel> _drive = new BindableCollection<WindowExplorerModel>();        
        private WindowExplorerModel _selectedDrive;

        public BindableCollection<WindowExplorerModel> Drive
        {
            get { return _drive; }
            set { _drive = value; }
        }               

        public WindowExplorerModel SelectedDrive
        {
            get { return _selectedDrive; }
            set
            {
                _selectedDrive = value;
                OnPropertyChanged(_selectedDrive);
            }
        }

        protected void OnPropertyChanged(WindowExplorerModel selectedItem)
        {
            if (selectedItem !=null)
            {
                Global.FullPath = selectedItem.FullPath;
                Global.Type = selectedItem.Type;            

                ((WindowExplorerViewModel)Parent).RefreshFolderScreen();
            }            
        }        

        public DriveViewModel()
        {
            GetLogicalDrives();
        }

        private void GetLogicalDrives()
        {
            Drive = new BindableCollection<WindowExplorerModel>();
            try
            {
                foreach(var drive in Directory.GetLogicalDrives())
                {
                    Drive.Add(new WindowExplorerModel { FullPath = drive, Name = drive, Type = "Drive" });
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
