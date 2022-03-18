using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Notepad.ViewModel
{
    public class TabModel : INotifyPropertyChanged
    {
        //TabControl MyTabControl;
   
        int TabIndex = 1;
        public string _Header;
        public string _Content;
        public string Header
        {
            get => _Header;
            set
            {
                _Header = "Tab "+TabIndex;
                OnPropertyChanged();
                TabIndex++;
            }
        }

        //ContentVM _Content = null;
        //public ContentVM Content
        //{
        //    get => _Content;
        //    set
        //    {
        //        _Content = value;
        //        OnPropertyChanged();
        //    }
        //}

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public class ContentVM
        {
            public ContentVM(string name, int index)
            {
                Name = name;
                Index = index;
            }
            public string Name { get; set; }
            public int Index { get; set; }
        }
    }
}

