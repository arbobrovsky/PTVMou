using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data.Entityes;
using PTVMou.Models;

namespace PTVMou.Controllers
{
    public class ManagerController : Controller
    {
        private readonly EFDBContext _context;

        public ManagerController(EFDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> ListPTV()
        {
            var model = await _context.PTV.ToListAsync();
            return View(model);
        }
        [HttpGet]
        public IActionResult CreateDepartment()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartment(Department department)
        {
            if (department != null)
            {
                if (ModelState.IsValid)
                {
                    await _context.Department.AddAsync(department);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Departmens()
        {
            var model = await _context.Department.ToListAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> CreateSubdivision()
        {
            var model = new SubdivisionViewModel();
            var departemns = await _context.Department.ToListAsync();
            var categoryes = await _context.Category.ToListAsync();
            model.Departments = departemns;
            model.Categoryes = categoryes;


            return View(model);
        }

        [Route("Manager/SubDivisions/{departmentId}")]
        [HttpGet]
        public async Task<IActionResult> SubDivisions(int departmentId)
        {
            var model = await _context.Subdivision
                .Include(x => x.Categoryes)
                .Include(x => x.Department)
                .Where(x => x.DepartmentId == departmentId)
                .ToListAsync();

            return View(model);
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(Categoryes categoryes)
        {
            await _context.Category.AddAsync(categoryes);
            await _context.SaveChangesAsync();

            return RedirectToAction("Norms");
        }


        [HttpPost]
        public async Task<IActionResult> CreateSubdivision(SubdivisionViewModel model)
        {
            if (model != null)
            {
                var reserv = new Reserve { Name = "Резерв " + model.Name };
                var battlecrew = new BattleСrew { Name = "Боевой расчет " + model.Name };
                var warehouse = new Warehouse { Name = "Склад" + model.Name };
                await _context.Reserve.AddAsync(reserv);
                await _context.BattleСrew.AddAsync(battlecrew);
                await _context.Warehouse.AddAsync(warehouse);
                await _context.SaveChangesAsync();

                var result = new Subdivision
                {
                    Name = model.Name,
                    CategoryesId = model.CategoryesId,
                    CountCarInBattleCrew = model.CountCar,
                    DepartmentId = model.DepartmentId,
                    BattleСrewId = battlecrew.BattleСrewId,
                    BattleСrew = battlecrew,
                    ReservId = reserv.ReserveId,
                    Reserve = reserv,
                    WarehouseId = warehouse.WarehouseId,
                    Warehouse = warehouse
                };
                await _context.Subdivision.AddAsync(result);
                await _context.SaveChangesAsync();
            }


            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Norms()
        {
            var model = new List<NormsSubDivisionViewModels>();
            foreach (var item in await _context.Norms.ToListAsync())
            {
                var category = await _context.Category.AsNoTracking().FirstOrDefaultAsync(x => x.CategoryesId == item.CategoryesId);
                model.Add(new NormsSubDivisionViewModels { NormsId = item.NormsId, Categoryes = category });
            }


            return View(model);
        }

        [Route("Manager/NormEdit/{NormsId}")]
        [HttpGet]
        public async Task<IActionResult> NormEdit(int NormsId)
        {
            var model = new NormsViewModel();
            var list = new List<NormsPTVViewModel>();
            var norms = await _context.Norms.AsNoTracking().FirstOrDefaultAsync(x => x.NormsId == NormsId);
            var category = await _context.Category.AsNoTracking().FirstOrDefaultAsync(x => x.CategoryesId == norms.CategoryesId);
            model.Categoryes = category;
            var ptv = await _context.PTV.ToListAsync();
            var ptvWithNormsId = await _context.Norms_PTVs.AsNoTracking().Where(x => x.NormsId == norms.NormsId).ToListAsync();
            foreach (var item in ptvWithNormsId)
            {
                //var ptv = await _context.PTV.AsNoTracking().FirstOrDefaultAsync(x => x.PTVId == item.PTVId);
                list.Add(new NormsPTVViewModel
                {
                    Norms_PTVId = item.Norms_PTVId,
                    NormsId = item.NormsId,
                    PTV = ptv.FirstOrDefault(x => x.PTVId == item.PTVId),
                    NormsCount = item.NormsCount,
                    WarehouseNormsCount = item.WarehouseNormsCount,
                    OnCar = item.OnCar
                });
            }
            model.NormsPTV = list;

            return View(model);
        }

        public async Task<IActionResult> PostPTV()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PostPTV(Norms sss)
        {

            //var norms = new Norms { CategoryesId = 2 };
            //await _context.Norms.AddAsync(norms);
            //await _context.SaveChangesAsync();
            //foreach (var item in await _context.PTV.ToListAsync())
            //{
            //    await _context.Norms_PTVs.AddAsync(new Norms_PTV { NormsId = norms.NormsId, PTVId = item.PTVId, NormsCount = 0, WarehouseNormsCount = 0 });
            //}
            //await _context.SaveChangesAsync();
            return View();
        }

        [Route("Manager/PostNorms/{norm_ptvId}/{NormsCount}/{WarehouseCount}/{onCar}")]
        [HttpPost]
        public async Task<bool> PostNorms(string norm_ptvId, string NormsCount, string WarehouseCount, string onCar)
        {
            var norma_ptv = await _context.Norms_PTVs.AsNoTracking().FirstOrDefaultAsync(x => x.Norms_PTVId == int.Parse(norm_ptvId));
            norma_ptv.NormsCount = int.Parse(NormsCount);
            norma_ptv.WarehouseNormsCount = decimal.Parse(WarehouseCount);
            norma_ptv.OnCar = bool.Parse(onCar);
            _context.Entry(norma_ptv).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return true;
        }




        [Route("Manager/EditSubdivision/{subdivisionId}")]
        [HttpGet]
        public async Task<IActionResult> EditSubdivision(int subdivisionId)
        {
            var PTV_Battle_Reserv_Warehouse = new List<PTV_Battle_Reserv_WarehouseViewModel>();
            var subdivision = await _context.Set<Subdivision>()
                .Include(x => x.BattleСrew)
                .Include(x => x.Reserve)
                .Include(x => x.Warehouse)
                .FirstOrDefaultAsync(x => x.SubdivisionId == subdivisionId);

            subdivision.Reserve.Reserve_PTVs = await _context.ReservePTV.Where(x => x.ReserveId == subdivision.ReservId).ToListAsync();
            subdivision.BattleСrew.BattleСrew_PTV = await _context.BattleСrew_PTV.Where(x => x.BattleСrewId == subdivision.BattleСrewId).ToListAsync();
            subdivision.Warehouse.Warehouse_PTVs = await _context.Warehouse_PTV.Where(x => x.WarehouseId == subdivision.WarehouseId).ToListAsync();


            var norma = await _context.Norms.AsNoTracking().Include(x => x.Norms_PTVs)
                .FirstOrDefaultAsync(x => x.CategoryesId == subdivision.CategoryesId);

            var ptv = await _context.PTV.ToListAsync();
            foreach (var item in norma.Norms_PTVs)
            {
                var countBattleСrew = subdivision.BattleСrew.BattleСrew_PTV.FirstOrDefault(x => x.PTVId == item.PTVId);
                var countReserv = subdivision.Reserve.Reserve_PTVs.FirstOrDefault(x => x.PTVId == item.PTVId);
                var countWarehouse = subdivision.Warehouse.Warehouse_PTVs.FirstOrDefault(x => x.PTVId == item.PTVId);

                PTV_Battle_Reserv_Warehouse.Add(new PTV_Battle_Reserv_WarehouseViewModel
                {
                    PTV = ptv.FirstOrDefault(x => x.PTVId == item.PTVId),
                    BattleCrewView = new BattleCrewView
                    {
                        CountNormal = (item.NormsCount * (subdivision.CountCarInBattleCrew / 2)),
                        CountNow = (countBattleСrew == null ? 0 : countBattleСrew.Count),
                        CountEnd = (countBattleСrew == null ? 0 : countBattleСrew.NeedPTV)
                    },
                    ReservView = new ReservView
                    {
                        CountNormal = (item.NormsCount * (subdivision.CountCarInBattleCrew / 2)),
                        CountNow = (countReserv == null ? 0 : countReserv.Count),
                        CountEnd = (countReserv == null ? 0 : countReserv.NeedPTV)
                    },

                    WarehouseView = new WarehouseView
                    {
                        CountNormal = (item.OnCar != true ? decimal.ToInt32(item.WarehouseNormsCount) : decimal.ToInt32(((subdivision.CountCarInBattleCrew * item.NormsCount) * item.WarehouseNormsCount)) / 2),
                        CountNow = (countWarehouse == null ? 0 : countWarehouse.Count),
                        CountEnd = (countWarehouse == null ? 0 : countWarehouse.NeedPTV),
                    },
                });

            }

            var model = new BattleCrew_ReservViewModel
            {
                Subdivision = subdivision,
                PTV_Battle_Reserv_WarehouseViewModel = PTV_Battle_Reserv_Warehouse
            };

            return View(model);
        }



        [Route("Manager/PostBRW/{subdivisionId}/{PTVId}/{countBattle}/{needBattle}/{countReserv}/{needReserv}/{countWarehouse}/{needWarehouse}")]
        public async Task<bool> PostBRW(string subdivisionId, string PTVId, string countBattle, string needBattle, string countReserv, string needReserv, string countWarehouse, string needWarehouse)
        {
            var subdivision = await _context.Set<Subdivision>()
              .Include(x => x.BattleСrew)
              .Include(x => x.Reserve)
              .Include(x => x.Warehouse)
              .FirstOrDefaultAsync(x => x.SubdivisionId == int.Parse(subdivisionId));

            var Reserve_PTVs = await _context.ReservePTV.Where(x => x.ReserveId == subdivision.ReservId).ToListAsync();
            var BattleСrew_PTV = await _context.BattleСrew_PTV.Where(x => x.BattleСrewId == subdivision.BattleСrewId).ToListAsync();
            var Warehouse_PTVs = await _context.Warehouse_PTV.Where(x => x.WarehouseId == subdivision.WarehouseId).ToListAsync();

            var resultBattle = new BattleСrew_PTV
            {
                PTVId = int.Parse(PTVId),
                Count = int.Parse(countBattle),
                NeedPTV = int.Parse(needBattle),
                BattleСrewId = subdivision.BattleСrewId,
                BattleСrew = subdivision.BattleСrew,
            };
            var resultReserv = new ReservePTV
            {
                PTVId = int.Parse(PTVId),
                Count = int.Parse(countReserv),
                NeedPTV = int.Parse(needReserv),
                ReserveId = subdivision.ReservId,
                Reserve = subdivision.Reserve
            };
            var resultWarehouse = new Warehouse_PTV
            {
                PTVId = int.Parse(PTVId),
                Count = int.Parse(countWarehouse),
                NeedPTV = int.Parse(needWarehouse),
                WarehouseId = subdivision.WarehouseId,
                Warehouse = subdivision.Warehouse
            };

            if (BattleСrew_PTV.FirstOrDefault(x => x.PTVId == int.Parse(PTVId)) == null)
            {
                await _context.BattleСrew_PTV.AddAsync(resultBattle);
            }
            else
            {
                var battleCrew = await _context.BattleСrew_PTV.FirstOrDefaultAsync(x => x.PTVId == int.Parse(PTVId));
                battleCrew.Count = int.Parse(countBattle);
                battleCrew.NeedPTV = int.Parse(needBattle);
                _context.Entry(battleCrew).State = EntityState.Modified;
            }

            if (Reserve_PTVs.FirstOrDefault(x => x.PTVId == int.Parse(PTVId)) == null)
            {
                await _context.ReservePTV.AddAsync(resultReserv);
            }
            else
            {
                var reserve = await _context.ReservePTV.FirstOrDefaultAsync(x => x.PTVId == int.Parse(PTVId));
                reserve.Count = int.Parse(countReserv);
                reserve.NeedPTV = int.Parse(needReserv);
                _context.Entry(reserve).State = EntityState.Modified;
            }

            if (Warehouse_PTVs.FirstOrDefault(x => x.PTVId == int.Parse(PTVId)) == null)
            {
                await _context.Warehouse_PTV.AddAsync(resultWarehouse);
            }
            else
            {
                var warehouse = await _context.Warehouse_PTV.FirstOrDefaultAsync(x => x.PTVId == int.Parse(PTVId));
                warehouse.Count = int.Parse(countWarehouse);
                warehouse.NeedPTV = int.Parse(needWarehouse);
                _context.Entry(warehouse).State = EntityState.Modified;
            }
            await _context.SaveChangesAsync();

            return true;
        }

    }
}