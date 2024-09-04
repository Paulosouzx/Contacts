using MeuSiteMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace MeuSiteMVC.Data
{
    public class BancoContext : DbContext 
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {  
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
