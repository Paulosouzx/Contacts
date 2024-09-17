using MeuSiteMVC.Data.Map;
using MeuSiteMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace MeuSiteMVC.Data
{
    public class BancoContext : DbContext 
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {  
        }

        public DbSet<ContactModel> Contacts { get; set; }
        public DbSet<UserModel> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContactMap());

            base.OnModelCreating(modelBuilder); 
        }
    }
}
