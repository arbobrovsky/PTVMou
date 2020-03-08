using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Data.Entityes
{
    public class BattleСrew
    {
        public int BattleСrewId { get; set; }
        public string Name { get; set; }

        public IList<BattleСrew_PTV> BattleСrew_PTV { get; set; }

        public BattleСrew()
        {
            BattleСrew_PTV = new List<BattleСrew_PTV>();
        }
    }
}