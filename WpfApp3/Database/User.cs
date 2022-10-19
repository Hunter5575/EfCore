﻿using System;
using System.Collections.Generic;

namespace WpfApp3.Database
{
    public partial class User
    {
        public int IdUsers { get; set; }
        public string? NickName { get; set; }
        public string Login { get; set; } = null!;
        public string Pass { get; set; } = null!;
        public string Post { get; set; } = null!;
        public byte[]? ImagePreview { get; set; }
    }
}
