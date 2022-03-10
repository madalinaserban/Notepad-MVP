using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notepad
{
   public class Document
    {
        public Document _document;
        public string _text;
       public string m_file_name;
        public string pt;
        public bool save_flag;
        public int countss;
        public string filename;
     public  Document()
        {
             pt = "";
            save_flag = false;
            countss = 0;
            filename = "";
            m_file_name = "";
        }
       public void set_path(string path)
        {
            pt = path;
        }
    }
}
