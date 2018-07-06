using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RegEdit
{
    public enum RegType
    {
        REG_SZ,
        REG_DWORD,
        REG_BINARY 
    }

    public class RegItem : INotifyPropertyChanged
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; OnChanged(); }
        }

        private RegType type;
        public RegType Type
        {
            get { return type; }
            set { type = value; OnChanged(); }
        }

        private byte[] data;
        public byte[] Data
        {
            get { return data; }
            set { data = value; OnChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnChanged([CallerMemberName]string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
