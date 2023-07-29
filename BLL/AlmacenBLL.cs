using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PaxSender.Data;
using PaxSender.Models;
#nullable disable

namespace PaxSender.BLL
{

public  class AlmacenBLL
 {
   
    private Contexto _contexto;

    public AlmacenBLL(Contexto contexto){
        _contexto = contexto;
    }

    public bool Existe(int almacenId){
        return _contexto.Almacen.Any(o => o.AlmacenId == almacenId);
    }

    private bool Insertar(Almacen almacen){
         _contexto.Almacen.Add(almacen);
        int cantidad = _contexto.SaveChanges();
        _contexto.Entry(almacen).State = EntityState.Detached;
        return cantidad > 0;
    }

    private bool Modificar(Almacen almacen){
        _contexto.Almacen.Update(almacen);
        int cantidad = _contexto.SaveChanges();
        _contexto.Entry(almacen).State = EntityState.Detached;
        return cantidad > 0;
    }

    public bool Guardar(Almacen almacen){
        if (!Existe(almacen.AlmacenId))
            return this.Insertar(almacen);
        else
            return this.Modificar(almacen);
    }

    public bool Eliminar(Almacen almacen){
         _contexto.Almacen.Remove(almacen);
        int cantidad = _contexto.SaveChanges();
        _contexto.Entry(almacen).State = EntityState.Detached;
        return cantidad > 0;
    }

     public Almacen Buscar(int id)
    {
        return _contexto.Almacen
            .Where(s => s.AlmacenId == id && s.Visible == true)
            .SingleOrDefault();
    }

    public List<Almacen> GetList(Expression<Func<Almacen, bool>> Criterio){
            return _contexto.Almacen
                .AsNoTracking()
                .Where(Criterio)
                .ToList();
        }
}
}