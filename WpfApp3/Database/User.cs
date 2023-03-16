using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApp3.Database
{
    public partial class User : INotifyPropertyChanged
    {
        public int IdUsers { get; set; }
        public string? NickName { get; set; }
        public string Login { get; set; } = null!;
        public string Pass { get; set; } = null!;
        public string Post { get; set; } = null!;

        private byte[]? Image;
        public byte[]? ImagePreview
        {
            get { return Image; }
            set
            {
                Image = value;
                PropChange();
            }
        }

        public bool IsPost=>Post=="Admin";
        public event PropertyChangedEventHandler PropertyChanged;
        private void PropChange([CallerMemberName] string PropName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(PropName));
        }
        
    }
}
