using Infrastructure.Base;
using Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class Mentor : BaseModel
    {
        public string Name { get; set; }
        public string UniName { get; set; }
        public double Distance { get; set; }
        public DateTime BeforeLastProcedureDate { get; set; }
        public DateTime LastProcedureDate { get; set; }
        public Level Level { get; set; }

        public List<Procedure> Procedures { get; set; }
        public Science Science { get; set; }
    }
}
