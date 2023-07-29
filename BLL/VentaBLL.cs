using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PaxSender.Data;

#nullable disable

namespace PaxSender.BLL
{

    public  class VentaBLL
    {
        private Contexto _contexto;

        public VentaBLL(Contexto contexto)
        {
            this._contexto = contexto;
        }


        public bool Existe(int Id)
        {
            return _contexto.Venta
                .Any(c => c.VentaId == Id);
        }

        public bool Guardar(Venta venta)
        {
            if (!Existe(venta.VentaId))
                return this.Insertar(venta);
            else
                return this.Modificar(venta);
        }


        private bool Insertar(Venta venta)
        {
            try
            {

                if(venta != null)
                {
                    if(venta.DetalleVenta != null)
                    {
                        foreach(var item in venta.DetalleVenta)
                        {
                            var articulo = _contexto.Articulo.Find(item.ArticuloId);
                            if(articulo != null)
                            {
                                articulo.Existencia -= item.Cantidad;
                                _contexto.Articulo.Update(articulo);
                                _contexto.SaveChanges();
                                _contexto.Entry(articulo).State = EntityState.Detached;
                            }
                        }
                        _contexto.Venta.Add(venta);
                        bool Guardo = _contexto.SaveChanges() > 0;
                        _contexto.Entry(venta).State = EntityState.Detached;
                        return Guardo;
                    }
                    else
                    {
                        return false;
                    }
                    
                }
                else
                {
                    return false;
                }

                

            }
            catch
            {
                throw;
            }
            
        }

        private bool Modificar(Venta venta)
        {
            try
            {
                if(venta!= null)
                {
                    var ventaAnterior = _contexto.Venta
                    .Where(e => e.VentaId == venta.VentaId)
                    .Include(e => e.DetalleVenta)
                    .AsNoTracking()
                    .SingleOrDefault();
                

                    if(ventaAnterior != null)
                    {
                        if(ventaAnterior.DetalleVenta != null)
                        {
                            foreach(var item in ventaAnterior.DetalleVenta)
                            {
                                var articulo = _contexto.Articulo.Find(item.ArticuloId);
                                if(articulo != null)
                                {
                                    articulo.Existencia += item.Cantidad;
                                    _contexto.Articulo.Update(articulo);
                                    _contexto.SaveChanges();
                                    _contexto.Entry(articulo).State = EntityState.Detached;
                                }
                            }
                            
                        }
                        
                    }
                    if(venta.DetalleVenta != null)
                    {
                        if(venta.DetalleVenta != null)
                        {
                            foreach(var item in venta.DetalleVenta)
                            {
                                var articulo = _contexto.Articulo.Find(item.ArticuloId);
                                if(articulo != null)
                                {
                                    articulo.Existencia -= item.Cantidad;
                                    _contexto.Articulo.Update(articulo);
                                    _contexto.SaveChanges();
                                    _contexto.Entry(articulo).State = EntityState.Detached;
                                }
                            }
                            
                        }
                    }
                    _contexto.Set<VentaDetalle>().RemoveRange(ventaAnterior.DetalleVenta);
                    _contexto.Set<VentaDetalle>().AddRange(venta.DetalleVenta);
                    _contexto.Venta.Update(venta);
                    int cantidad = _contexto.SaveChanges();
                    _contexto.Entry(venta).State= EntityState.Detached;
                    return cantidad > 0;
                    
                   
                }
                else
                {
                    return false;
                }

                

            }
            catch
            {
                throw;
            }

            

            
        }
        public bool Eliminar(Venta venta)
        {
            try
            {

                if(venta != null)
                {
                    if(venta.DetalleVenta != null)
                    {
                        foreach(var item in venta.DetalleVenta)
                        {
                            var articulo = _contexto.Articulo.Find(item.ArticuloId);
                            if(articulo != null)
                            {
                                articulo.Existencia += item.Cantidad;
                                _contexto.Articulo.Update(articulo);
                                _contexto.SaveChanges();
                                _contexto.Entry(articulo).State = EntityState.Detached;
                            }
                        }
                        _contexto.Venta.Remove(venta);
                        bool Guardo = _contexto.SaveChanges() > 0;
                        _contexto.Entry(venta).State = EntityState.Detached;
                        return Guardo;
                    }
                    else
                    {
                        return false;
                    }
                    
                }
                else
                {
                    return false;
                }

                

            }
            catch
            {
                throw;
            }
            
        }


        public Venta Buscar(int VentaId)
        {
            return _contexto.Venta
                .Include(c => c.DetalleVenta)
                .Where(c => c.VentaId == VentaId && c.Visible == true)
                .AsNoTracking()
                .SingleOrDefault();
        }

        
        public List<Venta> GetList()
        {
            return _contexto.Venta.Where(o => o.Visible==true ).AsNoTracking().ToList();
        }

        public List<Venta> FindList(int Buscado)
        {
            return _contexto.Venta.Where(o=>o.Visible == true && o.VentaId == Buscado).AsNoTracking().ToList();
        }

    }
    
}