using Microsoft.EntityFrameworkCore;
using PaxSender.Models;

namespace PaxSender.Data;
public class Contexto: DbContext
{
    public DbSet<Suplidor> Suplidor { get; set; }
    public Contexto (DbContextOptions <Contexto> options): base(options) 
    {
        
    }
}