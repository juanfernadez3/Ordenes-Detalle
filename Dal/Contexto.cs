using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using OrdenesDeCompra.Entidades;

namespace OrdenesDeCompra.Dal
{
    public class Contexto : DbContext
    {
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Ordenes> Ordenes { get; set; }
        public DbSet<Productos> Productos { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Datasource =  Data\ProductoDB");
        }
    }
}
