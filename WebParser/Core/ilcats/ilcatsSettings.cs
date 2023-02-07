using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebParser.Core.ParserInterfaces;

namespace WebParser.Core.ilcats
{
    class ilcatsSettings : IParserSettigs
    {
        public string BaseUrl { get; set; } = "https://www.ilcats.ru";
        public string Prefix { get; set; } = "/toyota/?function=getModels&market=EU&language=en";
    }
}
