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

            TreeItemsElem = new ObservableCollection<TreeViewItem>();

            var sub = new TreeViewItem();
            sub.Header = "Computer";

            TreeItemsElem.Add(sub);

            for (int i = 0; i < 5; i++)
            {

            }

            var keysRoot = Registry.ClassesRoot;
            var keysUser = Registry.CurrentUser;
            var keysLCMachine = Registry.LocalMachine;
            var keysUsers = Registry.Users;
            var keysCurConf = Registry.CurrentConfig;

            foreach (var item in keysRoot.GetSubKeyNames())
            {
                var subsub = new TreeViewItem();
                subsub.Header = item;

                sub.Items.Add(subsub);
            }
        }

        private void GetSubKeys(RegistryKey SubKey)
        {
            foreach (string sub in SubKey.GetSubKeyNames())
            {
                MessageBox.Show(sub);
                RegistryKey local = Registry.Users;
                local = SubKey.OpenSubKey(sub, true);
                GetSubKeys(local); // By recalling itself it makes sure it get all the subkey names
            }
        }

        //void FillCol(RegistryKey sub)
        //{
        //    foreach (var item in sub.GetSubKeyNames())
        //    {
        //        var subsub = new TreeViewItem();
        //        subsub.Header = item;

        //        sub.Items.Add(subsub);
        //    }
        //}

        //class Key
        //{
        //    public string KeyName { get; set; }
        //    public List<KeyValuePair<string, object>> Values { get; set; }
        //}

        //private List<Key> GetSubkeysValue(string path, RegistryHive hive)
        //{
        //    var result = new List<Key>();
        //    using (var hiveKey = RegistryKey.OpenBaseKey(hive, RegistryView.Default))
        //    using (var key = hiveKey.OpenSubKey(path))
        //    {
        //        var subkeys = key.GetSubKeyNames();

        //        foreach (var subkey in subkeys)
        //        {
        //            var values = GetKeyValue(hiveKey, subkey);
        //            result.Add(values);
        //        }
        //    }
        //    return result;
        //}

        //private Key GetKeyValue(RegistryKey hive, string keyName)
        //{
        //    var result = new Key() { KeyName = keyName };
        //    using (var key = hive.OpenSubKey(keyName))
        //    {
        //        foreach (var valueName in key.GetValueNames())
        //        {
        //            var val = key.GetValue(valueName);
        //            var pair = new KeyValuePair<string, object>(valueName, val);
        //            result.Values.Add(pair);
        //        }
        //    }

        //    return result;
        //}

        //public void SearchSubKeys(RegistryKey root, String searchKey)
        //{

        //    foreach (string keyname in root.GetSubKeyNames())
        //    {
        //        try
        //        {
        //            using (RegistryKey key = root.OpenSubKey(keyname))
        //            {
        //                if (keyname == searchKey)
        //                    Console.WriteLine("Registry key found : {0} contains {1} values",
        //                        key.Name, key.ValueCount);

        //                SearchSubKeys(key, searchKey);
        //            }
        //        }
        //        catch (System.Security.SecurityException)
        //        {
        //        }
        //    }
        //}
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
