
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PaxSender.Data;

//#nullable disable

namespace PaxSender.BLL
{

    public  class SalidaBLL    
    {
        private Contexto _contexto;
        public SalidaBLL(Contexto contexto)
        {
            _contexto = contexto;
        }

        public bool Guardar(Salida Salida)
        {
            if (!Existe(Salida.OrdenID))
                return Insertar(Salida);
            else
                return Modificar(Salida);
        }

        public bool Existe(int OrdenID)
        {
            return _contexto.Salida.Any(o => o.OrdenID== OrdenID);
        }

        private bool Insertar(Salida Salida)
        {
            _contexto.Salida.Add(Salida);
            int cantidad = _contexto.SaveChanges();
            _contexto.Database.ExecuteSqlRaw($"UPDATE Articulo SET Existencia = Existencia - {Salida.Cantidad}  WHERE ArticuloId={Salida.ArticuloId}");
            return cantidad > 0;
        }

        public bool Modificar(Salida Salida)
        {
            _contexto.Salida.Update(Salida);
            int cantidad = _contexto.SaveChanges();
            _contexto.Entry(Salida).State = EntityState.Detached;
            return cantidad > 0;
        }
        
        public List<Salida> GetSalidaDetalles()
        {
            return _contexto.Salida.ToList();
        }

            public bool Eliminar(Salida Salida)
            {
                _contexto.Entry(Salida).State=EntityState.Deleted;
                _contexto.Database.ExecuteSqlRaw($"DELETE FROM Salida WHERE OrdenID={Salida.OrdenID};");
                _contexto.Entry(Salida).State = EntityState.Detached;
                return _contexto.SaveChanges()>0;
            }   

            public Salida? Buscar(int OrdenID)
            {
                return _contexto.Salida
                        .Where(o => o.OrdenID==OrdenID ).AsNoTracking().SingleOrDefault();
                        
            }
            public List<Salida> GetList()
            {
                return _contexto.Salida.Where(o=>o.Visible == true).AsNoTracking().ToList();
            
            }
            public bool hidden(Salida Salida)
            {
                _contexto.Salida.Update(Salida);
                int cantidad = _contexto.SaveChanges();
                _contexto.Database.ExecuteSqlRaw($"UPDATE Salida SET Visible = false  WHERE SalidaID={Salida.OrdenID}");
                _contexto.Database.ExecuteSqlRaw($"UPDATE Articulo SET Existencia = Existencia + {Salida.Cantidad}  WHERE ArticuloId={Salida.ArticuloId}");
                _contexto.Entry(Salida).State = EntityState.Detached;
                return cantidad > 0;
            }

    }
}

    