﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wsb
{
    public abstract class Product
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public string Producer { get; set; }
        public string Code { get; set; }
    }
}