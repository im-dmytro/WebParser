using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebParser.Models
{
    class Complectation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string GroupPartUrl { get; set; }

        public int ModelId { get; set; }
        public Model Model { get; set; }

        public List<PartsGroup> GroupPart { get; set; }
    }

}
