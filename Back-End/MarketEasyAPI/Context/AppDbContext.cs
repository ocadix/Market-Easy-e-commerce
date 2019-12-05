using System;
using MarketEasyAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace MarketEasyAPI.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :
            base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Compras> Compras { get; set; }
    }
}
