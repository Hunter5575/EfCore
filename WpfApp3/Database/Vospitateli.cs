using System;
using System.Collections.Generic;

namespace WpfApp3.Database
{
    public partial class Vospitateli
    {
        public int IdVospitateli { get; set; }
        public string Fio { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public byte[]? ImagePreview { get; set; }
    }
}
