﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebParser.Core.ParserInterfaces
{
    internal interface IGetItemLinks
    {
        public List<string> hrefLinks { get; set; }
    }
}
