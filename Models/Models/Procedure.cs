using Infrastructure.Base;
using Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class Procedure : BaseModel
    {
        public DateTime Date { get; set; }
        public List<Mentor> mentors { get; set; }
        public Level Level { get; set; }
        public Science Science { get; set; }
    }
}
