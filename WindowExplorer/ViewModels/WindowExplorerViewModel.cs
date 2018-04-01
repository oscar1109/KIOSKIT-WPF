using Caliburn.Micro;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WindowExplorer.ViewModels
{
    public class WindowExplorerViewModel : Conductor<object>.Collection.AllActive
    {
        public Screen DriveViewModel { get; set; }
        public Screen FolderViewModel { get; set; }
        public Screen FileViewModel { get; set; }

        public WindowExplorerViewModel()
        {
            DriveViewModel = new DriveViewModel();
            FolderViewModel = new FolderViewModel();
            FileViewModel = new FileViewModel();

            Items.Add(DriveViewModel);
            Items.Add(FolderViewModel);
            Items.Add(FileViewModel);
        }
        

        public void RefreshFolderScreen()
        {
            FolderViewModel = new FolderViewModel();
            Items.Add(FolderViewModel);
            RefreshFileScreen();
            this.Refresh();        
        }

        public void RefreshFileScreen()
        {
            FileViewModel = new FileViewModel();
            FileViewModel.Refresh();
            this.Refresh();
        }
    }
}
