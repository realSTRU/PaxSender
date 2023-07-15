using Microsoft.EntityFrameworkCore;
using PaxSender.Models;

namespace PaxSender.Data;
public class Contexto: DbContext
{
    public DbSet<Suplidor> Suplidor { get; set; }
    public DbSet<Categoria> Categoria { get; set; }

    public DbSet<Cliente> Cliente {get; set;}

    public DbSet<Pedido> Pedido {get; set;}

    public DbSet<Articulo> Articulo{get; set;}
    public Contexto (DbContextOptions <Contexto> options): base(options) 
    {
        
    }
}