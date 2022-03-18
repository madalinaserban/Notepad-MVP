
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notepad.ViewModel
{
    public class MainViewModel
    { 
        private DocumentModel _document;
        public DocumentViewModel File{get; set;}
        public About AboutFile { get; set; }
        public TabModel Tab_model { get; set; }
        public MainViewModel()
        {
            _document = new DocumentModel();
            File = new DocumentViewModel(_document);
            AboutFile = new About();
        }

    }
}
