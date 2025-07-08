using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using DBC.Classes;
using Microsoft.EntityFrameworkCore;
using TychkclLibraryFund;


namespace DBC
{
    public class Context : DbContext
    {

        public DbSet<Classes.Library> Library { get; set; }
        public DbSet<Classes.Literature> Literature { get; set; }
        public DbSet<Classes.LiteratureType> LiteratureType { get; set; }
        public DbSet<Classes.Refill> Refill { get; set; }
        public DbSet<Classes.User> User { get; set; }
        public DbSet<Classes.UserRole> UserRoles { get; set; }
        public DbSet<Classes.UserOrder> UserOrder { get; set; }

        public Context()
        {
            try
            {
                Database.EnsureCreated();
            }
            catch
            {
                return;
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(DB.con, DB.MySQL);
        }
    }
}
