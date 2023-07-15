using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PaxSender.Data;

//#nullable disable

namespace PaxSender.BLL
{

    public  class ClienteBLL
    {
    
        private Contexto _contexto;

        public ClienteBLL (Contexto contexto)
        {
            _contexto = contexto;
        }
    

        public bool Existe(int ClienteId){
            return _contexto.Cliente.Any(o => o.ClienteId == ClienteId);
        }

        private bool Insertar(Cliente cliente){
            _contexto.Cliente.Add(cliente);
            int cantidad = _contexto.SaveChanges();
            _contexto.Entry(cliente).State = EntityState.Detached;
            return cantidad > 0;
        }

        private bool Modificar(Cliente cliente){
        _contexto.Cliente.Update(cliente);
        int cantidad = _contexto.SaveChanges();
        _contexto.Entry(cliente).State = EntityState.Detached;
        return cantidad > 0;
        }

        public bool Guardar(Cliente cliente){
            if (!Existe(cliente.ClienteId))
                return this.Insertar(cliente);
            else
                return this.Modificar(cliente);
        }

        public bool Eliminar(Cliente cliente){
            _contexto.Cliente.Remove(cliente);
            int cantidad = _contexto.SaveChanges();
            _contexto.Entry(cliente).State = EntityState.Detached;
            return cantidad > 0;
        }

        public Cliente Buscar(int Id)
        {
            return _contexto.Cliente
                .Where(c => c.ClienteId == Id && c.Visible == true)
                .SingleOrDefault();
        }

        public List<Cliente> GetList(Expression<Func<Cliente, bool>> Criterio){
                return _contexto.Cliente
                    .AsNoTracking()
                    .Where(Criterio)
                    .ToList();
            }
    }
}