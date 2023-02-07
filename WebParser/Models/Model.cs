using Microsoft.EntityFrameworkCore;


namespace WebParser.Models
{
    class Model
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Assembly { get; set; }
        public string ComplecationUrl { get; set; }
        public List<Complectation>? Complectations { get; set; }

        public override string ToString()
        {
            return String.Format("Name {0}{5}Code {1}{5}ProductionDate {2:MM.yyyy} - {3:MM.yyyy}{5}Assembly {4} href - {6};", Name, Code, StartDate, EndDate, Assembly, Environment.NewLine,ComplecationUrl);
        }
    }

}
