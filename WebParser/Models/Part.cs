using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebParser.Models
{
    internal class Part
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string? ReplacementCode { get; set; }
        public int? Count { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Info { get; set; }
        public string TreeCode { get; set; }
        public string Tree { get; set; }
        public string ImageName { get; set; }

        public int PartsSubGroupId { get; set; }
        public PartsSubGroup PartsSubGroup { get; set; }
    }
}
