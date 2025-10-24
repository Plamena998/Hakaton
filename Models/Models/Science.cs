using Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class Science : BaseModel
    { 
        public string Name { get; set; }

        public List<Mentor> Mentors { get; set; }
        //
    }
}
