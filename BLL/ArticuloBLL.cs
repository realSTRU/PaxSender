using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PaxSender.Data;

#nullable disable

namespace PaxSender.BLL
{

    public  class ArticuloBLL
    {
    
        private Contexto _contexto;

        public ArticuloBLL (Contexto contexto)
        {
            _contexto = contexto;
        }
    

        public bool Existe(int ArticuloId){
            return _contexto.Articulo.Any(o => o.ArticuloId == ArticuloId);
        }

        private bool Insertar(Articulo articulo){
            VerificarArticulo(articulo);
            _contexto.Articulo.Add(articulo);
            int cantidad = _contexto.SaveChanges();
            _contexto.Entry(articulo).State = EntityState.Detached;
            return cantidad > 0;
        }

        private bool Modificar(Articulo articulo){
            VerificarArticulo(articulo);
            _contexto.Articulo.Update(articulo);
            int cantidad = _contexto.SaveChanges();
            _contexto.Entry(articulo).State = EntityState.Detached;
            return cantidad > 0;
        }

        public bool Guardar(Articulo articulo){
            if (!Existe(articulo.ArticuloId))
                return this.Insertar(articulo);
            else
                return this.Modificar(articulo);
        }

        public bool Eliminar(Articulo articulo){
            _contexto.Articulo.Remove(articulo);
            int cantidad = _contexto.SaveChanges();
            _contexto.Entry(articulo).State = EntityState.Detached;
            return cantidad > 0;
        }

        public Articulo Buscar(int Id)
        {
            return _contexto.Articulo
                .Where(c => c.ArticuloId== Id && c.Visible == true)
                .SingleOrDefault();
        }

        public List<Articulo> GetListPerecederos()
        {
            return _contexto.Articulo
            .AsNoTracking()
            .Where(a => a.Estado.Contains("PERECEDERO"))
            .ToList();
        }

        public List<Articulo> GetListWithParameter(string? Buscado)
        {
            return _contexto.Articulo
            .AsNoTracking()
            .Where(a => a.Estado.Contains(Buscado))
            .ToList();
        }
        
        

        public List<Articulo> GetListReorden()
        {
            return _contexto.Articulo
            .AsNoTracking()
            .Where(a => a.Existencia <= a.Num_Reorden)
            .ToList();
        }

        public List<Articulo> GetList(Expression<Func<Articulo, bool>> Criterio){
                List<Articulo> articulos = _contexto.Articulo
                    .AsNoTracking()
                    .Where(Criterio)
                    .ToList();

                foreach(var item in articulos)
                {
                    VerificarArticulo(item);

                }

                return articulos;
            }

        public bool VerificarArticulo(Articulo articulo)
        {
            
            if(DateTime.Compare(articulo.Fecha_Caducidad, DateTime.Now) < 0)
            {
                articulo.Estado = ESTADOS.PERECEDERO.ToString();
                _contexto.Articulo.Update(articulo);
                _contexto.Entry(articulo).State = EntityState.Detached;
            }
            else 
            {
                articulo.Estado = ESTADOS.ACTIVO.ToString();
                _contexto.Articulo.Update(articulo);
                _contexto.Entry(articulo).State = EntityState.Detached;
            }

            if(articulo.Existencia <= articulo.Num_Reorden)
            {
                articulo.Estado = ESTADOS.REORDEN.ToString();
                _contexto.Articulo.Update(articulo);
                _contexto.Entry(articulo).State = EntityState.Detached;
            }

            int cantidad = _contexto.SaveChanges();
            _contexto.Entry(articulo).State = EntityState.Detached;
           
            return cantidad > 0;
        }
    }
}