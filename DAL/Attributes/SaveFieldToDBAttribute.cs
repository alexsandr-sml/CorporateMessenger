﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Attributes
{
    public class SaveFieldToDBAttribute : Attribute
    {
        public bool Enable { get; set; }
    }
}
