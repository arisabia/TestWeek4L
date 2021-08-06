using Microsoft.EntityFrameworkCore;
using System;
using TestWeek4L.Core.EF.Configurations;
using TestWeek4L.Core.Model;

namespace TestWeek4L.Core.EF
{
    public class OrdineContext : DbContext
    {
        public DbSet<Ordine> Ordini { get; set; }
        public DbSet<Cliente> Clienti { get; set; }

        public OrdineContext() : base() { }

        public OrdineContext(DbContextOptions<OrdineContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optBuilder)
        {
            optBuilder.UseSqlServer(@"Persist Security Info = False; Integrated Security = true; 
                                    Initial Catalog = OrdineC; Server = .\SQLEXPRESS");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Ordine>(new OrdineConfiguration());
            modelBuilder.ApplyConfiguration<Cliente>(new ClienteConfiguration());
        }
    }
}
