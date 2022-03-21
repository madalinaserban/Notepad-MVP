using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
namespace Notepad
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


        }
        // TabItem t = tab.SelectedItem;
        public int CurrentSelectedTab()
        {
            int i = tab.SelectedIndex;
            return i;
        }

        private void OnTabCloseClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
    
