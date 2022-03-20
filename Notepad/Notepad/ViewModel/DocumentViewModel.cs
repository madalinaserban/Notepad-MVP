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
        private bool save = false;
        public DocumentModel Document { get; set; }
        public ICommand NewCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand SaveAsCommand { get; }
        public ICommand OpenCommand { get; }
        public ICommand ExitCommand { get; }
        public DocumentViewModel(DocumentModel document)
        {
            Tabs = new ObservableCollection<DocumentModel>();
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
            DocumentModel t = new DocumentModel()
            {
                FileName = "File 1",
                Text = " "
            };

            Tabs.Add(t);
        }
        private void SaveFile()
        {if (save == false)
            {
                SaveFileAs();
            }
            else
            { File.WriteAllText(Document.FilePath, Document.Text); }
        }

        private void SaveFileAs()
        {
            DocumentModel t = Tabs[Tabs.Count() - 1];
            var saveFileDialog = new Microsoft.Win32.SaveFileDialog();
            saveFileDialog.Filter = "Text File (*.txt)|*.txt";
            if (saveFileDialog.ShowDialog() == true)
            {
                save = true;
                File.WriteAllText(saveFileDialog.FileName, t.Text);
                Document.FileName = saveFileDialog.SafeFileName;
                Document.FilePath = saveFileDialog.FileName;
            }
        }

        private void OpenFile()
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                DocumentModel t = new DocumentModel()
                {
                    Text = File.ReadAllText(openFileDialog.FileName),
                    FileName = openFileDialog.SafeFileName,
                    FilePath = openFileDialog.FileName
                };
                Tabs.Add(t);
            }

        }
    }
}
