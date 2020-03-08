using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entityes
{
    public class ReservePTV
    {
        public int ReservePTVId { get; set; }
        public int PTVId { get; set; }
        public int Count { get; set; }
        public int NeedPTV { get; set; }
        public int ReserveId { get; set; }
        public Reserve Reserve { get; set; }
    }
}
