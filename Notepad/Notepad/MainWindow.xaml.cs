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
using System.Windows.Shell;
using TextBox = System.Windows.Controls.TextBox;
namespace Notepad
{
public partial class MainWindow : Window
    {
        int TabIndex = 1;
        ObservableCollection<TabVM> Tabs = new ObservableCollection<TabVM>();
        public MainWindow()
        {
            InitializeComponent();
            var tab1 = new TabVM()
            {
                Header = $"Tab {TabIndex}",
                Content = new ContentVM("First tab", 1)
            };
            Tabs.Add(tab1);
            AddNewPlusButton();

            MyTabControl.ItemsSource = Tabs;
            MyTabControl.SelectionChanged += MyTabControl_SelectionChanged;

        }

        private void MyTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl)
            {
                var pos = MyTabControl.SelectedIndex;
                if (pos != 0 && pos == Tabs.Count - 1) //last tab
                {
                    var tab = Tabs.Last();
                    ConvertPlusToNewTab(tab);
                    AddNewPlusButton();
                }
            }
        }

        void ConvertPlusToNewTab(TabVM tab)
        {
            //Do things to make it a new tab.
            TabIndex++;
            tab.Header = $"Tab {TabIndex}";
            tab.IsPlaceholder = false;
            tab.Content = new ContentVM("Tab content", TabIndex);
        }

        void AddNewPlusButton()
        {
            var plusTab = new TabVM()
            {
                Header = "+",
                IsPlaceholder = true
            };
            Tabs.Add(plusTab);
        }

        class TabVM : INotifyPropertyChanged
        {
            string _Header;
            public string Header
            {
                get => _Header;
                set
                {
                    _Header = value;
                    OnPropertyChanged();
                }
            }

            bool _IsPlaceholder = false;
            public bool IsPlaceholder
            {
                get => _IsPlaceholder;
                set
                {
                    _IsPlaceholder = value;
                    OnPropertyChanged();
                }
            }

            ContentVM _Content = null;
            public ContentVM Content
            {
                get => _Content;
                set
                {
                    _Content = value;
                    OnPropertyChanged();
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string property = "")
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
            }
        }

        class ContentVM
        {
            public ContentVM(string name, int index)
            {
                Name = name;
                Index = index;
            }
            public string Name { get; set; }
            public int Index { get; set; }
        }

        private void OnTabCloseClick(object sender, RoutedEventArgs e)
        {
            var tab = (sender as Button).DataContext as TabVM;
            if (Tabs.Count > 2)
            {
                var index = Tabs.IndexOf(tab);
                if (index == Tabs.Count - 2)//last tab before [+]
                {
                    MyTabControl.SelectedIndex--;
                }
                Tabs.RemoveAt(index);
            }
        }
    }
}
    
