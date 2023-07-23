using Microsoft.EntityFrameworkCore;
using PaxSender.Models;

namespace PaxSender.Data;
public class Contexto: DbContext
{
    public DbSet<Suplidor> Suplidor { get; set; }
    public DbSet<Categoria> Categoria { get; set; }

    public DbSet<Salida> Salida {get; set;}
    
    public DbSet<Entrada> Entrada {get; set;}
    public DbSet<Sucursal> Sucursal {get; set;}

    public DbSet<Cliente> Cliente {get; set;}

    public DbSet<Pedido> Pedido {get; set;}

    public DbSet<Articulo> Articulo{get; set;}
    public Contexto (DbContextOptions <Contexto> options): base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>().HasData(
            new Categoria
            {
                CategoriaId = 1,
                Descripcion = "Inmuebles"
            },
             new Categoria
            {
                CategoriaId = 2,
                Descripcion = "Alimentos"
            },
             new Categoria
            {
                CategoriaId = 3,
                Descripcion = "Ropa"
            }
        );
    }
}