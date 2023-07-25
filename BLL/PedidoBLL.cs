using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PaxSender.Data;

#nullable disable

namespace PaxSender.BLL
{

    public  class PedidoBLL
    {
        private Contexto _contexto;

        public PedidoBLL(Contexto contexto)
        {
            this._contexto = contexto;
        }


        public bool Existe(int Id)
        {
            return _contexto.Pedido
                .Any(c => c.PedidoId == Id);
        }

        public bool Guardar(Pedido pedido)
        {
            if (!Existe(pedido.PedidoId))
                return this.Insertar(pedido);
            else
                return this.Modificar(pedido);
        }


        private bool Insertar(Pedido pedido)
        {
            

            _contexto.Pedido.Add(pedido);

            bool Guardo = _contexto.SaveChanges() > 0;

            _contexto.Entry(pedido).State = EntityState.Detached;

            return Guardo;

        }

        private bool Modificar(Pedido pedido)
        {

            _contexto.Pedido.Update(pedido);
            var modificado = _contexto.SaveChanges() > 0;
            _contexto.Entry(pedido).State = EntityState.Detached;
            return modificado;

            
        }
        public bool Eliminar(Pedido pedido)
        {

            _contexto.Database.ExecuteSqlRaw($"UPDATE Pedido SET Visible = false WHERE PedidoId = {pedido.PedidoId}");
            _contexto.Database.ExecuteSqlRaw($"UPDATE PedidoDetalle SET Visible = false WHERE PedidoId = {pedido.PedidoId}");
            return _contexto.SaveChanges() > 0;
        }

        public Pedido? Buscar(int PedidoId)
        {
            return _contexto.Pedido
                .Include(c => c.DetallePedido)
                .Where(c => c.PedidoId == PedidoId && c.Visible == true)
                .AsNoTracking()
                .SingleOrDefault();
        }

        
        public List<Pedido> GetList()
        {
            return _contexto.Pedido.Where(o => o.Visible==true && (o.Estado.Contains("PENDIENTE") || o.Estado.Contains("EMPACADO") ||  o.Estado.Contains("ENCAMINO") ||
             o.Estado.Contains("RECIBIDO") ) ).AsNoTracking().ToList();
        }

        public List<Pedido> FindList(int Buscado)
        {
            return _contexto.Pedido.Where(o=>o.Visible == true && o.PedidoId == Buscado).AsNoTracking().ToList();
        }

    }
    
}