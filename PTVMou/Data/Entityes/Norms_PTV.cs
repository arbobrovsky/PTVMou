using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entityes
{
    public class Norms_PTV
    {
        public int Norms_PTVId { get; set; }
        public int PTVId { get; set; }
        public decimal WarehouseNormsCount { get; set; }
        public bool OnCar { get; set; }
        public int NormsCount { get; set; }
        public int NormsId { get; set; }
        public virtual Norms Norms { get; set; }
    }
}
