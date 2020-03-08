using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entityes
{
    public class Warehouse_PTV
    {
        public int Warehouse_PTVId { get; set; }
        public int PTVId { get; set; }
        public int Count { get; set; }
        public int NeedPTV { get; set; }
        public int WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }
    }
}
