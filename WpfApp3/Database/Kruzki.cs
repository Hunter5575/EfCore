using System;
using System.Collections.Generic;

namespace WpfApp3.Database
{
    public partial class Kruzki
    {
        public int IdKruzki { get; set; }
        public string Name { get; set; } = null!;
        public string Dayofweek { get; set; } = null!;
        public string Group { get; set; } = null!;
        public string Vospitatel { get; set; } = null!;
        public string Assistent { get; set; } = null!;
        public byte[]? ImagePreview { get; set; }
    }
}
