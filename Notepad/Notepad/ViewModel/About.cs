using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Notepad.ViewModel
{
    public class About : ObsObject
    {public ICommand AboutCommand { get; }
        public About()
        {
            AboutCommand = new RelayCommand(CommandAbout);
        }
        private void CommandAbout()
        {
            var helpDialog = new Info();
            helpDialog.ShowDialog();
        }
    }
}
