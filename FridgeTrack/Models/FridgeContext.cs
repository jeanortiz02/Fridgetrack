using Microsoft.EntityFrameworkCore;

namespace FridgeTrack.Models
{
    public class FridgeContext : DbContext
    {
        public FridgeContext(DbContextOptions<FridgeContext> options) : base(options)
        {
        }

        public DbSet<Alimento> Alimentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alimento>().HasData(
                new Alimento { Id = 1, Nombre = "Leche", Categoria = "Lacteos", Cantidad = 2, FechaVencimiento = new DateTime(2026, 11, 28) },
                new Alimento { Id = 2, Nombre = "Huevos", Categoria = "Proteinas", Cantidad = 12, FechaVencimiento = new DateTime(2026, 12, 10) },
                new Alimento { Id = 3, Nombre = "Queso blanco", Categoria = "Lacteos", Cantidad = 1, FechaVencimiento = new DateTime(2026, 11, 25) },
                new Alimento { Id = 4, Nombre = "Pechuga de pollo", Categoria = "Carnes", Cantidad = 3, FechaVencimiento = new DateTime(2026, 11, 24) },
                new Alimento { Id = 5, Nombre = "Lechuga", Categoria = "Vegetales", Cantidad = 1, FechaVencimiento = new DateTime(2026, 11, 26) },
                new Alimento { Id = 6, Nombre = "Jugo de naranja", Categoria = "Bebidas", Cantidad = 1, FechaVencimiento = new DateTime(2026, 12, 5) }
            );
        }
    }
}
