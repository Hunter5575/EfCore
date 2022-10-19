using System;
using System.Collections.Generic;

namespace WpfApp3.Database
{
    public partial class DopPersonal
    {
        public int IdDopPersonal { get; set; }
        public string Fio { get; set; } = null!;
        public int Phone { get; set; }
        public string Profession { get; set; } = null!;
        public byte[]? ImagePreview { get; set; }
    }
}
