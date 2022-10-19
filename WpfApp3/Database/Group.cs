using System;
using System.Collections.Generic;

namespace WpfApp3.Database
{
    public partial class Group
    {
        public int IdGroup { get; set; }
        public int KolVoChild { get; set; }
        public string NameVospitateli { get; set; } = null!;
        public string Nomer { get; set; } = null!;
        public string Kruzki { get; set; } = null!;
        public string Meropriyatiya { get; set; } = null!;
        public byte[]? ImagePreview { get; set; }
    }
}
