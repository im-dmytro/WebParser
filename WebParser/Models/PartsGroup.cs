using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebParser.Models
{
    internal class PartsGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }

        public string PartsSubGroupUrl { get; set; }

        public int ComplectationId { get; set; }
        public Complectation Complectation { get; set; }

        public List<PartsSubGroup> PartsSubGroups { get; set; }
    }
}
