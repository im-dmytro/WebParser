using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebParser.Core.ParserInterfaces
{
    interface IParserSettigs
    {
        string BaseUrl { get; set; }
        string Prefix { get; set; }
    }
}

