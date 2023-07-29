using Microsoft.EntityFrameworkCore;
using PaxSender.Models;

namespace PaxSender.Data;
public class Contexto: DbContext
{
    public DbSet<Suplidor> Suplidor { get; set; }
    public DbSet<Categoria> Categoria { get; set; }

    public DbSet<Pedido> Pedido {get; set; }

    public DbSet<Salida> Salida {get; set;}
    
    public DbSet<Entrada> Entrada {get; set;}
    public DbSet<Sucursal> Sucursal {get; set;}

    public DbSet<Venta> Venta {get; set;}
    public DbSet<Almacen> Almacen {get; set;}

    public DbSet<Envio> Envio {get; set;}
    public DbSet<Cliente> Cliente {get; set;}

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
            },
             new Categoria
            {
                CategoriaId = 4,
                Descripcion = "PaxSenderCategory"
            }

        );

        modelBuilder.Entity<Almacen>().HasData(
            new Almacen
            {
                AlmacenId = 1,
                Identificador = "ALMACEN GENERAL"
            }
            
            
        );

        modelBuilder.Entity<Suplidor>().HasData(
            new Suplidor
            {
                SuplidorId = 1,
                Nombre = "PaxSenderEssensials",
                Telefono ="0",
                Celular ="0",
                Direccion ="PaxSenderMainDireccion",
                RNC ="MainRNC",
                Correo ="PaxSender.Net"


            }
            
            
        );

      

        modelBuilder.Entity<Articulo>().HasData(
            new Articulo
            {
                ArticuloId = 1,
                SuplidorId = 1,
                AlmacenId = 1,
                CategoriaId = 4,
                Descripcion = "PAQUETE",
                Costo = 0,
                Precio = 0,
                Peso = 0,
                Existencia = 10000000,
                Fecha_Caducidad = DateTime.Now


            }
            
            
        );
          modelBuilder.Entity<Sucursal>().HasData(
            new Sucursal
            {
                
                SucursalId =1,
                Nombre ="Principal DO",
                Direccion = "NAGUA RD"

            }
            
            
        );
    }
}