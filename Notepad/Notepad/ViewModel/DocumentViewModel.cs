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
        public ICommand FindCommand { get; }
        public ICommand ReplaceCommand { get; }
        public ICommand ReplaceAllCommand { get; }

        public ICommand CloseTabCommand { get;}
        public DocumentViewModel(DocumentModel document)
        {
            Tabs = new ObservableCollection<DocumentModel>();
            Document = document;
            NewCommand = new RelayCommand(NewFile);
            SaveCommand = new RelayCommand(SaveFile);
            SaveAsCommand = new RelayCommand(SaveFileAs);
            OpenCommand = new RelayCommand(OpenFile);
            ExitCommand = new RelayCommand(Exit);
            FindCommand = new RelayCommand(Find);
            ReplaceCommand = new RelayCommand(Replace);
            ReplaceAllCommand = new RelayCommand(ReplaceAll);
           // CloseTabCommand = new RelayCommand(CloseTab);
        }

        private void Exit()
        {
            System.Windows.Application.Current.Shutdown();
        }
        public void Find()
        {
            var dialogBox = new DialogBox();
            string prop="Word to find :";
            dialogBox.CreateDialogBox(prop);
            dialogBox.ShowDialog();
            var response = dialogBox.GetResponseTexts();
            for(int i=0;i<Tabs.Count();i++)
            {
                if(Tabs[i].Text.Contains(response))
                {
                  Tabs[i].Text=  Tabs[i].Text.Replace(response, "!$!" + response + "!$!");
                }
            }
        }
        public void Replace()
        { 
            var dialogBox = new DialogBox();
            string prop = "Word to replace:";
            dialogBox.CreateDialogBox(prop);
            dialogBox.ShowDialog();
            var response = dialogBox.GetResponseTexts();
            string prop2 = "New word :";
            var dialogBox2 = new DialogBox();
            dialogBox2.CreateDialogBox(prop2);
            dialogBox2.ShowDialog();
            var response2 = dialogBox2.GetResponseTexts();
            for (int i = 0; i < Tabs.Count(); i++)
            {
                if (Tabs[i].Text.Contains(response))
                {
                    //Tabs[i].Text = "L-a gasit";
                    Tabs[i].Text = Tabs[i].Text.Replace(response, response2);
                    string name = Tabs[i].FileName;
                    if (name.Contains("*") == false)
                    { Tabs[i].FileName = Tabs[i].FileName + "*"; }
                }
                break;
            }
            
        }
        public void ReplaceAll()
        {
            var dialogBox = new DialogBox();
            string prop = "Word to replace:";
            dialogBox.CreateDialogBox(prop);
            dialogBox.ShowDialog();
            var response = dialogBox.GetResponseTexts();
            string prop2 = "New word :";
            var dialogBox2 = new DialogBox();
            dialogBox2.CreateDialogBox(prop2);
            dialogBox2.ShowDialog();
            var response2 = dialogBox2.GetResponseTexts();
            for (int i = 0; i < Tabs.Count(); i++)
            {
                if (Tabs[i].Text.Contains(response))
                {
                    //Tabs[i].Text = "L-a gasit";
                    Tabs[i].Text = Tabs[i].Text.Replace(response, response2);
                    string name = Tabs[i].FileName;
                    if (name.Contains("*") == false)
                    { Tabs[i].FileName = Tabs[i].FileName + "*"; }
                }
            }
        }
        public void NewFile()
        {
            DocumentModel t = new DocumentModel()
            {
                FileName = "File " +Tabs.Count()+"*",
                Text = " "
            };

            Tabs.Add(t);
        }
        private void SaveFile()
        {
             DocumentModel t = Tabs[Document.CurrentSelectedTab];

            if (t.save_flag)
            { File.WriteAllText(Document.FilePath, t.Text); Tabs[Document.CurrentSelectedTab].FileName = t.FileName.Replace("*", ""); }
            else { SaveFileAs();
                Tabs[Document.CurrentSelectedTab].FileName= t.FileName.Replace("*", "");
            }
        }

        private void SaveFileAs()
        { 
            DocumentModel t = Tabs[Document.CurrentSelectedTab];
            var saveFileDialog = new Microsoft.Win32.SaveFileDialog();
            saveFileDialog.Filter = "Text File (*.txt)|*.txt";
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, t.Text);
                Document.FileName = saveFileDialog.SafeFileName;
                Document.FilePath = saveFileDialog.FileName;
                t.FileName.Replace("*", "");
                Tabs[Document.CurrentSelectedTab].FileName = t.FileName.Replace("*", "");
                t.save_flag = true;
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
                    FilePath = openFileDialog.FileName,
                    save_flag = true
                };
                Tabs.Add(t);
            }

        }
     
    }
}
