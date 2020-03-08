using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entityes
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public virtual List<Subdivision> Subdivision { get; set; }

        public Department()
        {
            Subdivision = new List<Subdivision>();
        }
    }
}
