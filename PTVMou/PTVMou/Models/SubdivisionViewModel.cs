using Data.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTVMou.Models
{
    public class SubdivisionViewModel
    {
        public int SubdivisionId { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public virtual List<Department> Departments { get; set; }
    }
}
