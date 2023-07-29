using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PaxSender.Data;

#nullable disable

namespace PaxSender.BLL
{

    public  class EnvioBLL
    {
        private Contexto _contexto;

        public EnvioBLL(Contexto contexto)
        {
            this._contexto = contexto;
        }


        public bool Existe(int Id)
        {
            return _contexto.Envio
                .Any(c => c.EnvioId == Id);
        }

        public bool Guardar(Envio envio)
        {
            if (!Existe(envio.EnvioId))
                return this.Insertar(envio);
            else
                return this.Modificar(envio);
        }


        private bool Insertar(Envio envio)
        {
            try
            {

                if(envio != null)
                {
                    if(envio.DetalleEnvio != null)
                    {
                        foreach(var item in envio.DetalleEnvio)
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
                        _contexto.Envio.Add(envio);
                        bool Guardo = _contexto.SaveChanges() > 0;
                        _contexto.Entry(envio).State = EntityState.Detached;
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

        private bool Modificar(Envio envio)
        {
            try
            {
                if(envio!= null)
                {
                    var envioAnterior = _contexto.Envio
                    .Where(e => e.EnvioId == envio.EnvioId)
                    .Include(e => e.DetalleEnvio)
                    .AsNoTracking()
                    .SingleOrDefault();
                

                    if(envioAnterior != null)
                    {
                        if(envioAnterior.DetalleEnvio != null)
                        {
                            foreach(var item in envioAnterior.DetalleEnvio)
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
                    if(envio.DetalleEnvio != null)
                    {
                        if(envio.DetalleEnvio != null)
                        {
                            foreach(var item in envio.DetalleEnvio)
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
                    _contexto.Set<EnvioDetalle>().RemoveRange(envioAnterior.DetalleEnvio);
                    _contexto.Set<EnvioDetalle>().AddRange(envio.DetalleEnvio);
                    _contexto.Envio.Update(envio);
                    int cantidad = _contexto.SaveChanges();
                    _contexto.Entry(envio).State= EntityState.Detached;
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
        public bool Eliminar(Envio envio)
        {
            try
            {

                if(envio != null)
                {
                    if(envio.DetalleEnvio != null)
                    {
                        foreach(var item in envio.DetalleEnvio)
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
                        _contexto.Envio.Remove(envio);
                        bool Guardo = _contexto.SaveChanges() > 0;
                        _contexto.Entry(envio).State = EntityState.Detached;
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


        public Envio Buscar(int EnvioId)
        {
            return _contexto.Envio
                .Include(c => c.DetalleEnvio)
                .Where(c => c.EnvioId == EnvioId && c.Visible == true)
                .AsNoTracking()
                .SingleOrDefault();
        }

        
        public List<Envio> GetList()
        {
            return _contexto.Envio.Where(o => o.Visible==true && (o.Estado.Contains("PENDIENTE") || o.Estado.Contains("EMPACADO") ||  o.Estado.Contains("ENCAMINO") ||
             o.Estado.Contains("RECIBIDO") ) ).AsNoTracking().ToList();
        }

        public List<Envio> FindList(int Buscado)
        {
            return _contexto.Envio.Where(o=>o.Visible == true && o.EnvioId == Buscado).AsNoTracking().ToList();
        }

    }
    
}