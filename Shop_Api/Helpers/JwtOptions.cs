﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Helpers
{
    internal class JwtOptions
    {
        public string Issuer { get; set; }
        public string Key { get; set; }
        public int Lifetime { get; set; }
    }
}
