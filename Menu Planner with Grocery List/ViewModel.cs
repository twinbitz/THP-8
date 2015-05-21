using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using System.IO;

namespace Menu_Planner_with_Grocery_List
{
    class ViewModel : INotifyPropertyChanged
    {
        private StorageFolder _currentFolder;
        public StorageFolder CurrentFolder
        {
            get { return _currentFolder; }
            set
            {
                _currentFolder = value;
                NotifyPropertyChanged("CurrentFolder");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string p)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(p));
        }

        public void LoadDocumentsLibrary()
        {
            CurrentFolder = KnownFolders.DocumentsLibrary;
        }

        async public Task<StorageFile> CreateFile(string subFolderName, string fileName)
        {
            if (CurrentFolder != null)
            {
                var folder = await CurrentFolder.CreateFolderAsync(subFolderName, CreationCollisionOption.OpenIfExists);
                return await folder.CreateFileAsync(fileName, CreationCollisionOption.OpenIfExists).AsTask();
            }
            else return null;
        }

        async public Task<StorageFile> OpenFile(string subFolderName, string fileName)
        {
            if (CurrentFolder !=null)
            {
                var folder = await CurrentFolder.CreateFolderAsync(subFolderName, CreationCollisionOption.OpenIfExists);
                if (fileName != null)
                {
                    var file = folder.CreateFileAsync(fileName, CreationCollisionOption.OpenIfExists);
                }
                    return await folder.GetFileAsync(fileName);                
            }
                else return null;
        }

        private List<PlannerData> planners;
        public List<PlannerData> Planners
        {
            get { return planners; }
            set
            {
                planners = value;
                NotifyPropertyChanged("Planners");
            }
        }
    }
}
