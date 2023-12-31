using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

public class Pedido
{
    [Key]
    public int PedidoId { get; set; }

    public int ClienteId {get; set;}

    public DateTime Fecha { get; set; }

    public int SucursalId {get; set;}
    public string? Destino {get; set;}

    public double?  Total { get; set; }

    public string Estado { get; set; }

    public bool Visible {get; set;}

    [ForeignKey("PedidoId")]
    public List<PedidoDetalle> DetallePedido {get; set;}

    public Pedido()
    {
        this.Fecha = DateTime.Now;
        this.DetallePedido = new List<PedidoDetalle>();
        this.Visible = true;
        this.Estado = ESTADOPEDIDO.PENDIENTE.ToString();

    }

}

public class PedidoDetalle
{
    [Key]
    public int DetalleId  { get; set; }

    public int PedidoId {get; set;}

    public int ArticuloId {get; set;}

    public int Cantidad {get; set;}

    public double Precio {get; set;} = 0;

    public double? Importe {

        get  {return Cantidad * Precio;}

    }


}
public enum ESTADOPEDIDO{

    PENDIENTE,

    RECIBIDO,

    LIQUIDADO






}


