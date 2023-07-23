using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PaxSender.Data;

#nullable disable

namespace PaxSender.BLL
{

    public  class EntradaBLL
    {
    
        private Contexto _contexto;
    public EntradaBLL(Contexto contexto)
    {
        _contexto = contexto;
    }

    public bool Guardar(Entrada Entrada)
    {
        if (!Existe(Entrada.OrdenID))
            return Insertar(Entrada);
        else
            return Modificar(Entrada);
    }

    public bool Existe(int OrdenID)
    {
        return _contexto.Entrada.Any(o => o.OrdenID== OrdenID);
    }

    public bool Insertar(Entrada Entrada)
    {
        
        _contexto.Database.ExecuteSqlRaw($"UPDATE Articulo SET Existencia = Existencia + {Entrada.Cantidad}  WHERE ArticuloId={Entrada.ArticuloId}");
        _contexto.Entrada.Add(Entrada); 

        
        return _contexto.SaveChanges() > 0;
    }

    public bool Inventario(Entrada Entrada)
    {

        _contexto.Database.ExecuteSqlRaw($"UPDATE Articulo SET Existencia = {Entrada.Cantidad}  WHERE ArticuloId={Entrada.ArticuloId}");
       _contexto.Entrada.Add(Entrada);
        return _contexto.SaveChanges() > 0;
        

       
        
       
    }

    public bool Modificar(Entrada Entrada)
    {
        _contexto.Entrada.Update(Entrada);
        int cantidad = _contexto.SaveChanges();
        _contexto.Entry(Entrada).State = EntityState.Detached;
        return cantidad > 0;
    }
    
    public List<Entrada> GetEntradaDetalles()
    {
        return _contexto.Entrada.ToList();
    }

        public bool Eliminar(Entrada Entrada)
        {
            _contexto.Entry(Entrada).State=EntityState.Deleted;
            _contexto.Database.ExecuteSqlRaw($"DELETE FROM Entrada WHERE OrdenID={Entrada.OrdenID};");
            _contexto.Entry(Entrada).State = EntityState.Detached;
            return _contexto.SaveChanges()>0;
        }   

        public Entrada? Buscar(int OrdenID)
        {
            return _contexto.Entrada
                    .Where(o => o.OrdenID==OrdenID ).AsNoTracking().SingleOrDefault();
                    
        }
        public List<Entrada> GetList()
        {
            return _contexto.Entrada.Where(o=>o.Visible == true ).AsNoTracking().ToList();
        }
        public bool hidden(Entrada Entrada)
        {
            _contexto.Entrada.Update(Entrada);
            int cantidad = _contexto.SaveChanges();
            _contexto.Database.ExecuteSqlRaw($"UPDATE Entrada SET Visible = false  WHERE EntradaID={Entrada.OrdenID}");
            _contexto.Database.ExecuteSqlRaw($"UPDATE Articulo SET Existencia = Existencia - {Entrada.Cantidad}  WHERE ArticuloId={Entrada.ArticuloId}");
            _contexto.Entry(Entrada).State = EntityState.Detached;
            return cantidad > 0;
        }
    }
}