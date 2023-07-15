using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PaxSender.Data;
using PaxSender.Models;
#nullable disable

namespace PaxSender.BLL
{

public  class CategoriaBLL
 {
   
    private Contexto _contexto;

    public CategoriaBLL(Contexto contexto){
        _contexto = contexto;
    }

    public bool Existe(int categoriaId){
        return _contexto.Categoria.Any(o => o.CategoriaId == categoriaId);
    }

    private bool Insertar(Categoria categoria){
        _contexto.Categoria.Add(categoria);
        return _contexto.SaveChanges()> 0;
    }

    private bool Modificar(Categoria categoria){
        _contexto.Entry(categoria).State = EntityState.Modified;
        return _contexto.SaveChanges()> 0;
    }

    public bool Guardar(Categoria categoria){
        if (!Existe(categoria.CategoriaId))
            return this.Insertar(categoria);
        else
            return this.Modificar(categoria);
    }

    public bool Eliminar(Categoria categoria){
        _contexto.Entry(categoria).State = EntityState.Deleted;
        return _contexto.SaveChanges() > 0;
    }

     public Categoria Buscar(int id)
    {
        return _contexto.Categoria
            .Where(s => s.CategoriaId == id && s.Visible == true)
            .SingleOrDefault();
    }

    public List<Categoria> GetList(Expression<Func<Categoria, bool>> Criterio){
            return _contexto.Categoria
                .AsNoTracking()
                .Where(Criterio)
                .ToList();
        }
}
}