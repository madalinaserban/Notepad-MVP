
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Notepad
{
    public class DocumentModel : ObsObject
    {
        //public TabControl Tab_Control
        //{
        //    get { };

        //}
        private string _text;

        public string Text
        {
            get { return _text; }
            set { OnPropertyChanged(ref _text, value);
                //_text=value;
                //OnPropertyChanged("Text");
            }
        }
        private string _fileName;
        public string FileName
        {
            get { return _fileName; }
            set { OnPropertyChanged(ref _fileName, value); }
        }
        private string _filePath;
        public string FilePath
        {
            get { return _filePath; }
            set { OnPropertyChanged(ref _filePath, value); }
        }
        public string _Header;
        public string _Content;
    }
}
