using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
namespace Notepad.ViewModel
{
    public class DocumentViewModel
    {
        public ObservableCollection<DocumentModel> Tabs { get; set; }
        public DocumentModel Document { get; set; }
        public ICommand NewCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand SaveAsCommand { get; }
        public ICommand OpenCommand { get; }
        public ICommand ExitCommand { get; }
        public DocumentViewModel(DocumentModel document)
        {
            Document = document;
            NewCommand = new RelayCommand(NewFile);
            SaveCommand = new RelayCommand(SaveFile);
            SaveAsCommand = new RelayCommand(SaveFileAs);
            OpenCommand = new RelayCommand(OpenFile);
            ExitCommand = new RelayCommand(Exit);
        }

        private void Exit()
        {
            System.Windows.Application.Current.Shutdown();
        }
        public void NewFile()
        {
            Document.FileName = string.Empty;
            Document.FilePath = string.Empty;
            Document.Text = string.Empty;
            TabModel tab = new TabModel();
            {
                //  tab.Tabs.Add(tab);

              //  Tabs.Add(tab);
                //tab._Header = "a";
            };
        }

        private void SaveFile()
        {
            File.WriteAllText(Document.FilePath, Document.Text);
        }

        private void SaveFileAs()
        {
            var saveFileDialog = new Microsoft.Win32.SaveFileDialog();
            saveFileDialog.Filter = "Text File (*.txt)|*.txt";
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, Document.Text);
                Document.FileName = saveFileDialog.SafeFileName;
                Document.FilePath = saveFileDialog.FileName;
            }
        }

        private void OpenFile()
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Document.Text = File.ReadAllText(openFileDialog.FileName);
                Document.FileName = openFileDialog.SafeFileName;
                Document.FilePath = openFileDialog.FileName;
            }
        }
        //public ObservableCollection<TabItem> Tabs { get; set; };
        //private void MyTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (e.Source is System.Windows.Controls.TabControl)
        //    {
        //        var pos = MyTabControl.SelectedIndex;
        //        if (pos != 0 && pos == Tabs.Count - 1) //last tab
        //        {
        //            var tab = Tabs.Last();
        //            ConvertPlusToNewTab(tab);
        //            AddNewPlusButton();
        //        }
        //    }
        //}
    }
}
