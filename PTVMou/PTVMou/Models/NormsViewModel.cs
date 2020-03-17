using Data.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PTVMou.Models
{

    public class NormsSubDivisionViewModels
    {
        public int NormsId { get; set; }
        public Categoryes Categoryes { get; set; }
    }
  

    public class NormsViewModel
    {
        public int CategoryesId { get; set; }
        public Categoryes Categoryes { get; set; }
        public List<NormsPTVViewModel> NormsPTV { get; set; }
    }

    public class NormsPTVViewModel
    {
        public int Norms_PTVId { get; set; }
        public int NormsId { get; set; }
        public PTV PTV { get; set; }
        public int PTVId { get; set; }
        public decimal WarehouseNormsCount { get; set; }
        public bool OnCar { get; set; }
        public int NormsCount { get; set; }
        
    }
}
