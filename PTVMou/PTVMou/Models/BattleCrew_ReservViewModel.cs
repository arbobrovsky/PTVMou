﻿using Data.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTVMou.Models
{
    public class BattleCrew_ReservViewModel
    {
        public Subdivision Subdivision { get; set; }
        public List<PTV_Battle_Reserv_WarehouseViewModel> PTV_Battle_Reserv_WarehouseViewModel { get; set; }

    }

    public class PTV_Battle_Reserv_WarehouseViewModel
    {
        public PTV PTV { get; set; }
        public BattleCrewView BattleCrewView { get; set; }
        public ReservView ReservView { get; set; }
        public WarehouseView WarehouseView { get; set; }

    }

    public class BattleCrewView 
    {
        public int CountNormal { get; set; }
        public int CountNow { get; set; }
    }

    public class WarehouseView 
    {
        public int CountNormal { get; set; }
        public int CountNow { get; set; }
    }

    public class ReservView 
    {
        public int CountNormal { get; set; }
        public int CountNow { get; set; }
    }

}

