using Microsoft.EntityFrameworkCore;
using pr42.Modell;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr42.Classes
{
    public class ConnectionEntity:DbContext
    {
        private static readonly string config = "Server=DESKTOP-PTGUJU9\\SQLEXPRESS;Trusted_Connection=true;Encrypt=false; DataBase=pr45;";
        public DbSet<Items> items {  get; set; }
        public DbSet<Categorys> categorys { get; set; }

        public ConnectionEntity()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(config);
        }
    }
}
