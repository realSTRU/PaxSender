using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PaxSender.Data;
using PaxSender.Models;
#nullable disable

namespace PaxSender.BLL
{

public  class SuplidorBLL
 {
   
    private Contexto _contexto;

    public SuplidorBLL(Contexto contexto){
        _contexto = contexto;
    }

    public bool Existe(int personaId){
        return _contexto.Suplidor.Any(o => o.SuplidorId == personaId);
    }

    private bool Insertar(Suplidor suplidor){
        _contexto.Suplidor.Add(suplidor);
        return _contexto.SaveChanges()> 0;
    }

    private bool Modificar(Suplidor suplidor){
        _contexto.Entry(suplidor).State = EntityState.Modified;
        return _contexto.SaveChanges()> 0;
    }

    public bool Guardar(Suplidor suplidor){
        if (!Existe(suplidor.SuplidorId))
            return this.Insertar(suplidor);
        else
            return this.Modificar(suplidor);
    }

    public bool Eliminar(Suplidor suplidor){
        _contexto.Entry(suplidor).State = EntityState.Deleted;
        return _contexto.SaveChanges() > 0;
    }

     public Suplidor Buscar(int id)
    {
        return _contexto.Suplidor
            .Where(s => s.SuplidorId == id && s.Visible == true)
            .SingleOrDefault();
    }

    public List<Suplidor> GetList(Expression<Func<Suplidor, bool>> Criterio){
            return _contexto.Suplidor
                .AsNoTracking()
                .Where(Criterio)
                .ToList();
        }
}
}