using System;
using System.Collections.Generic;

namespace WpfApp3.Database
{
    public partial class Child
    {
        public int IdChildren { get; set; }
        public string Fio { get; set; } = null!;
        public int PhoneParents { get; set; }
        public long Age { get; set; }
        public string Group { get; set; } = null!;
        public byte[]? ImagePreview { get; set; }
    }
}
