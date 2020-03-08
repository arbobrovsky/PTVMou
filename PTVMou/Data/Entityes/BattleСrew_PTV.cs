using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Data.Entityes
{
    public class BattleСrew_PTV
    {
        public int BattleСrew_PTVId { get; set; }
        public int BattleСrewId { get; set; }
        public int PTVId { get; set; }
        public int Count { get; set; }
        public int NeedPTV { get; set; }
        public BattleСrew BattleСrew { get; set; }
    }
}