using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entityes
{
    public class Reserve
    {
        public int ReserveId { get; set; }
        public string Name { get; set; }
        public IList<ReservePTV> Reserve_PTVs { get; set; }

        public Reserve()
        {
            Reserve_PTVs = new List<ReservePTV>();
        }

    }
}
