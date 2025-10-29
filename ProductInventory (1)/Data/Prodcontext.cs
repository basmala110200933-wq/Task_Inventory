using Microsoft.EntityFrameworkCore;
using ProductInventory.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInventory.Data
{
    public class Prodcontext:DbContext
    {
        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-0OSQ4LI;Initial Catalog=InventoryManagment;Integrated Security=True;Trust Server Certificate=True");
        }
    }
}
