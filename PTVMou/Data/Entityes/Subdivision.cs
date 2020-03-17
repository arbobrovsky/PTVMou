using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entityes
{
    public class Subdivision
    {
        public int SubdivisionId { get; set; }
        public string Name { get; set; }
        public int CategoryesId { get; set; }
        public int CountCarInBattleCrew { get; set; }
        public int DepartmentId { get; set; }
        public int BattleСrewId { get; set; }
        public int ReservId { get; set; }
        public int WarehouseId { get; set; }
        public virtual Department Department { get; set; }
        public virtual Reserve Reserve { get; set; }
        public virtual Categoryes Categoryes { get; set; }
        public virtual BattleСrew BattleСrew { get; set; }
        public virtual Warehouse Warehouse { get; set; }
    }
}
