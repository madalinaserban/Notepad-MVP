
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notepad.ViewModel
{
    public class MainViewModel
    {
        public DocumentModel _document;
        public DocumentViewModel File { get; set; }
        public MainWindow Window;
        public About AboutFile { get; set; }
        public MainViewModel()
        {
            _document = new DocumentModel();
            File = new DocumentViewModel(_document);
            File.NewFile();
            AboutFile = new About();

        }
    

    }
}
