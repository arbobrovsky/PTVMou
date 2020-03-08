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
        public async Task<IActionResult> CreateSubdivision()
        {
            var model = new SubdivisionViewModel();
            var departemns = await _context.Department.ToListAsync();
            model.Departments = departemns;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubdivision(SubdivisionViewModel model)
        {

            if (model != null)
            {
                var reserv = new Reserve { Name = "Резерв " + model.Name };
                var battlecrew = new BattleСrew { Name = "Боевой расчет " + model.Name };
                await _context.Reserve.AddAsync(reserv);
                await _context.BattleСrew.AddAsync(battlecrew);
                await _context.SaveChangesAsync();

                var result = new Subdivision
                {
                    Name = model.Name,
                    DepartmentId = model.DepartmentId,
                    BattleСrewId = battlecrew.BattleСrewId,
                    ReservId = battlecrew.BattleСrewId
                };
                await _context.Subdivision.AddAsync(result);
                await _context.SaveChangesAsync();
            }


            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Norms()
        {
            var listNorms = new List<NormsViewModel>();
            var norms = await _context.Norms.ToListAsync();
            foreach (var item in norms)
            {
                var ptv = await _context.PTV.AsNoTracking().FirstOrDefaultAsync(x => x.PTVId == item.PTVId);

                listNorms.Add(new NormsViewModel { PTV = ptv, NormCount = item.NormsCount, WarehouseCount = item.WarehouseCount });
            }

            return View(listNorms);
        }


        [Route("Manager/EditSubdivision/{reservId?}")]
        [HttpGet]
        public async Task<IActionResult> EditSubdivision(int reservId)
        {
            var subdivision = await _context.Set<Subdivision>().Include(x => x.BattleСrew).Include(x => x.Reserve).AsNoTracking().FirstOrDefaultAsync(x => x.SubdivisionId == reservId);
            var norma = await _context.Norms.ToListAsync();
            var PTV_Battle_Reserv_Warehouse = new List<PTV_Battle_Reserv_WarehouseViewModel>();

            foreach (var item in norma)
            {
                var PTV = await _context.PTV.AsNoTracking().FirstOrDefaultAsync(x => x.PTVId == item.PTVId);
                PTV_Battle_Reserv_Warehouse.Add(new PTV_Battle_Reserv_WarehouseViewModel
                {
                    PTV = PTV,
                    BattleCrewView = new BattleCrewView { CountNormal = (item.NormsCount * subdivision.CountCarInBattleCrew), },
                    ReservView = new ReservView { CountNormal = (item.NormsCount * subdivision.CountCarInBattleCrew) },
                    WarehouseView = new WarehouseView { CountNormal = item.NormsCount }
                });
            }

            var model = new BattleCrew_ReservViewModel
            {
                Subdivision = subdivision,
                PTV_Battle_Reserv_WarehouseViewModel = PTV_Battle_Reserv_Warehouse
            };

            return View(model);
        }


        [Route("Manager/PostNorms/{PTVId}/{NormsCount}/{WarehouseCount}")]
        [HttpPost]
        public async Task<bool> PostNorms(string PTVId, string NormsCount, string WarehouseCount)
        {
            var norma = await _context.Norms.AsNoTracking().FirstOrDefaultAsync(x => x.PTVId == int.Parse(PTVId));
            norma.NormsCount = int.Parse(NormsCount);
            norma.WarehouseCount = decimal.Parse(WarehouseCount);
            _context.Entry(norma).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return true;
        }

        [Route("Manager/PostBReserv/{subdivisionId}/{PTVId}/{countBattle}/{needBattle}/{countReserv}/{needReserv}")]
        public async Task<bool> PostBReserv(string subdivisionId, string PTVId, string countBattle, string needBattle, string countReserv, string needReserv)
        {
            var subdivision = await _context.Subdivision.AsNoTracking().FirstOrDefaultAsync(x => x.SubdivisionId == int.Parse(subdivisionId));

            var equlBattle = await _context.BattleСrew_PTV.AsNoTracking().FirstOrDefaultAsync(x => x.PTVId == int.Parse(PTVId));
            var equlReserv = await _context.ReservePTV.AsNoTracking().FirstOrDefaultAsync(x => x.PTVId == int.Parse(PTVId));
            var equlWarehouse = await _context.ReservePTV.AsNoTracking().FirstOrDefaultAsync(x => x.PTVId == int.Parse(PTVId));

            var resultBattle = new BattleСrew_PTV
            {
                PTVId = int.Parse(PTVId),
                BattleСrewId = subdivision.BattleСrewId,
                Count = int.Parse(countBattle),
                NeedPTV = int.Parse(needBattle),
            };
            var resultReserv = new ReservePTV
            {
                PTVId = int.Parse(PTVId),
                ReserveId = subdivision.ReservId,
                Count = int.Parse(countReserv),
                NeedPTV = int.Parse(needReserv),
            };

            if (equlBattle.BattleСrew_PTVId == 0 && equlReserv.ReservePTVId == 0)
            {
                await _context.BattleСrew_PTV.AddAsync(resultBattle);
                await _context.ReservePTV.AddAsync(resultReserv);
                await _context.SaveChangesAsync();
            }

            return true;
        }

    }
}