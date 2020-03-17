using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entityes
{
    public class Norms
    {
        public int NormsId { get; set; }
        public int CategoryesId { get; set; }
        public virtual IEnumerable<Norms_PTV> Norms_PTVs { get; set; }
        public Norms()
        {
            Norms_PTVs = new List<Norms_PTV>();
        }
    }
}
