using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entityes
{
    public class Warehouse
    {
        public int WarehouseId { get; set; }
        public string Name { get; set; }
        public IList<Warehouse_PTV> Warehouse_PTVs { get; set; }

        public Warehouse()
        {
            Warehouse_PTVs = new List<Warehouse_PTV>();
        }
    }
}
