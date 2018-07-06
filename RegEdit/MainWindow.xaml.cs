using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RegEdit
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<TreeViewItem> TreeItemsElem { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            TreeItemsElem = new ObservableCollection<TreeViewItem> 
            {
                
            };

            var keysRoot = Registry.ClassesRoot;
            var keysUser = Registry.CurrentUser;
            var keysLCMachine = Registry.LocalMachine;
            var keysUsers = Registry.Users;
            var keysCurConf = Registry.CurrentConfig;

        }
    }
}

/*var keys = Registry.CurrentUser.GetSubKeyNames();
            foreach (var item in keys) {
                var subkey = Registry.CurrentUser.OpenSubKey(item);
                Console.WriteLine(subkey.Name.Split('\\').Last());
                var subkeysubkeys = subkey.GetSubKeyNames();
                foreach (var itemitem in subkeysubkeys) {
                    var subkeysubkey = subkey.OpenSubKey(itemitem);
                    Console.WriteLine("\t" + subkeysubkey.Name.Split('\\').Last());
                    var subkeysubkeysubkeys = subkeysubkey.GetSubKeyNames();
                    foreach (var itemitemitem in subkeysubkeysubkeys) {
                        var subkeysubkeysubkey = subkeysubkey.OpenSubKey(itemitemitem);
                        Console.WriteLine("\t\t" + subkeysubkeysubkey.Name.Split('\\').Last());

                        var subkeysubkeysubkeysubkeys = subkeysubkeysubkey.GetSubKeyNames();
                        foreach (var itemitemitemitem in subkeysubkeysubkeysubkeys) {
                            var subkeysubkeysubkeysubkey = subkeysubkeysubkey.OpenSubKey(itemitemitemitem);
                            Console.WriteLine("\t\t" + subkeysubkeysubkeysubkey.Name.Split('\\').Last());
                        }
                    }
                }
            }*/
