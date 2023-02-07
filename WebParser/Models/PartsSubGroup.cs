using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebParser.Models
{
    internal class PartsSubGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }

        public string PartsUrl { get; set; }

        public int PartsGroupId { get; set; }
        public PartsGroup PartsGroup { get; set; }

        public List<Part> Parts { get; set; }


    }
}
