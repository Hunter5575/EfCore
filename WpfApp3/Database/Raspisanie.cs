using System;
using System.Collections.Generic;

namespace WpfApp3.Database
{
    public partial class Raspisanie
    {
        public int IdRaspisanie { get; set; }
        public string Dayofweek { get; set; } = null!;
        public string NameVospitateli { get; set; } = null!;
        public string Nomer { get; set; } = null!;
        public string? Kruzki { get; set; }
        public string? Meropriyatiya { get; set; }
        public byte[]? ImagePreview { get; set; }
    }
}
