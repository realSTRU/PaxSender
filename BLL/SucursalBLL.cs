using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PaxSender.Data;
using PaxSender.Models;
#nullable disable

namespace PaxSender.BLL
{

public  class SucursalBLL
 {
   
    private Contexto _contexto;

    public SucursalBLL(Contexto contexto){
        _contexto = contexto;
    }

    public bool Existe(int SucursalId){
        return _contexto.Sucursal.Any(s => s.SucursalId == SucursalId);

    }
    private bool Insertar(Sucursal sucursal){
        _contexto.Sucursal.Add(sucursal);
        int cantidad = _contexto.SaveChanges();
        _contexto.Entry(sucursal).State = EntityState.Detached;
        return cantidad > 0;
    }

    private bool Modificar(Sucursal sucursal){
        _contexto.Sucursal.Update(sucursal);
        int cantidad = _contexto.SaveChanges();
        _contexto.Entry(sucursal).State = EntityState.Detached;
        return cantidad > 0;

    }

    public bool Guardar(Sucursal sucursal){
        if (!Existe(sucursal.SucursalId))
            return this.Insertar(sucursal);
        else
            return this.Modificar(sucursal);
    }

    public bool Eliminar(Sucursal sucursal){
        _contexto.Sucursal.Remove(sucursal);
        int cantidad = _contexto.SaveChanges();
        _contexto.Entry(sucursal).State= EntityState.Detached;
        return cantidad > 0;
    }

     public Sucursal Buscar(int id)
    {
        return _contexto.Sucursal
            .Where(s => s.SucursalId == id && s.Visible == true)
            .SingleOrDefault();
    }

    public List<Sucursal> GetList(Expression<Func<Sucursal, bool>> Criterio){
            return _contexto.Sucursal
                .AsNoTracking()
                .Where(Criterio)
                .ToList();
        }
}
}