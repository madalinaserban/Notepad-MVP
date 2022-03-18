using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Notepad
{
   public class ObsObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged<T>(ref T property, T value, [CallerMemberName] string propertyname = "")
            {
            property = value;
            var handler = PropertyChanged;
            if(handler!=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
            }
        private ObservableCollection<UserControl> _pageViews;


        public ObservableCollection<UserControl> PageViews
        {
            get
            {
                if (_pageViews == null)
                {
                    _pageViews = new ObservableCollection<UserControl>();
                }
                return _pageViews;
            }
        }
    }

}
