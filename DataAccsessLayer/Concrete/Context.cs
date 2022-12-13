using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsessLayer.Concrete
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-HD6BB26\\SQLEXPRESS;database=GopStoreDb;integrated security=true");
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Setler> Setlers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)   // Çoka çok bağlantı için method oluşturuyorum çünkü
        {                                                                    // bir tabloda birden fazla key oluşturamıyoruz..
            modelBuilder.Entity<Users_Setler>().HasKey(x => new { x.UserID, x.SetID});
        }
    }
}