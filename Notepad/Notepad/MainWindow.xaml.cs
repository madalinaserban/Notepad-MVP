using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using TextBox = System.Windows.Controls.TextBox;
namespace Notepad
{

    public partial class MainWindow : Window
    {
        int numar = 0;
        Document document=new Document();
        
        public MainWindow()
        {
            InitializeComponent();
        }
        private void SaveFile(object sender, RoutedEventArgs e)
        {
            if (document.save_flag == false)
            { SaveFileAs(sender, e); }
            else
            {
                File.WriteAllText(document.filename, tx1.Text);
              
            }

        }
        private void Open(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == true)
            {
                this.tx1.Clear();
                string path = openFileDialog.FileName;
                document.set_path(path);
                int pos = path.LastIndexOf("\\");
                string ss = path.Substring(pos + 1);
                // Open the file to read from.   

                using (StreamReader sr = File.OpenText(path))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        this.tx1.AppendText(s + Environment.NewLine);

                        document.countss = document.countss + s.Length + 1;
                    }
                    JumpList.AddToRecentCategory(path);
                }
            }


        }
        //private System.Windows.Controls.TextBox GetTextBox()
        //{
        //    //System.Windows.Controls.TextBox tb = null;
        //    //TabPage tp=new TabPage();
        //    //tab_control.SelectedTab

        //    //  TabPage tp = tp.SelectedTab();
        //    //object tp = tab_control.SelectedItem;
        //    //if (tp != null)
        //    //{
        //    //    tb=tp
        //    //}
        //    //return tb;
        //}
        private TextBox GetTextBox()
        { TextBox tb = null;
            for(int i=0;i<=numar;i++)
            {
                if(tab_control.SelectedIndex==i)
                {
                    
                }
            }
            return tb;
        }
        private void New(object sender, RoutedEventArgs e)
        {
            numar++;
            MainWindow w = new MainWindow();
            TabItem tp = new TabItem
            {
                Header = "Tab-" + numar,
            };
            // tp.Content=w;
            //tp.Content = new MainWindow();
            tab_control.Items.Add(tp);

        }

        private void OnNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(e.Uri.AbsoluteUri);
            e.Handled = true;
        }
        private void DisplayInfo(object sender, RoutedEventArgs e)
        {
            Info about = new Info();
            about.ShowDialog();
        }
        private void SaveFileAs(object sender, RoutedEventArgs e)
        {

            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.DefaultExt = ".txt";
            dlg.FileName = "Notepad.txt";
            if (dlg.ShowDialog() == true)
            {
                File.WriteAllText(dlg.FileName, tx1.Text);
                document.filename = dlg.FileName;
            }
            document.save_flag = true;
        }
        private void Exit(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void Find(object sender, EventArgs e)
        {
            tx1.FindName(Name);
        }
        //private void Recent(object sender, RoutedEventArgs e)
        //{
        //    JumpList jumpList = new JumpList();
        //    jumpList.ShowRecentCategory = true;
        //    JumpList.SetJumpList(Application.Current, jumpList);
        //}
    }
}
