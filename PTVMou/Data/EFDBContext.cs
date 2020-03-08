using Data.Entityes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class EFDBContext : DbContext
    {
        public EFDBContext(DbContextOptions<EFDBContext> options) : base(options)
        {
        }

        public DbSet<BattleСrew> BattleСrew { get; set; }
        public DbSet<BattleСrew_PTV> BattleСrew_PTV { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<PTV> PTV { get; set; }
        public DbSet<Reserve> Reserve { get; set; }
        public DbSet<ReservePTV> ReservePTV { get; set; }
        public DbSet<Subdivision> Subdivision { get; set; }
        public DbSet<Warehouse> Warehouse { get; set; }
        public DbSet<Warehouse_PTV> Warehouse_PTV { get; set; }
        public DbSet<Norms> Norms { get; set; }
    }
}
