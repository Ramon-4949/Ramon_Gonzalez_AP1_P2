using Microsoft.EntityFrameworkCore;
using Ramon_Gonzalez_AP1_P2.Models;
using System.Collections.Generic; 

namespace Ramon_Gonzalez_AP1_P2.Context
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<Entrada> Entradas { get; set; }
        public DbSet<EntradaDetalle> EntradasDetalle { get; set; }
        public DbSet<Producto> Productos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Producto>().HasData(new List<Producto>()
            {
                new Producto
                {
                    ProductoId = 1,
                    Descripcion = "Maní",
                    Peso = 0,
                    Existencia = 100,
                    EsCompuesto = false
                },
                new Producto
                {
                    ProductoId = 2,
                    Descripcion = "Pistachos",
                    Peso = 0,
                    Existencia = 100,
                    EsCompuesto = false
                },
                new Producto
                {
                    ProductoId = 3,
                    Descripcion = "Almendras",
                    Peso = 0,
                    Existencia = 100,
                    EsCompuesto = false
                },
                new Producto
                {
                    ProductoId = 4,
                    Descripcion = "Frutos Mixtos 200gr",
                    Peso = 200.00,
                    Existencia = 0,
                    EsCompuesto = true
                },
                new Producto
                {
                    ProductoId = 5,
                    Descripcion = "Frutos Mixtos 400gr",
                    Peso = 400.00,
                    Existencia = 0,
                    EsCompuesto = true
                },
                new Producto
                {
                    ProductoId = 6,
                    Descripcion = "Frutos Mixtos 600gr",
                    Peso = 600.00,
                    Existencia = 0,
                    EsCompuesto = true
                }
            });
        }
    }
}