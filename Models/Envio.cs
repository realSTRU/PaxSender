using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

public class Envio
{
    [Key]
    public int EnvioId { get; set; }

    public int ClienteId {get; set;}

    public DateTime Fecha { get; set; }

    public int SucursalId {get; set;}
    public string? Destino {get; set;}

    public double?  Total { get; set; }

    public double Total_Envio {get; set;}

    public string Estado { get; set; }

    public string Etiqueta {get; set;}

    public string Destinatario_Referencia {get; set;}

    public bool Visible {get; set;}

    [ForeignKey("PedidoId")]
    public List<EnvioDetalle> DetalleEnvio {get; set;}

    public Envio()
    {
        this.Fecha = DateTime.Now;
        this.DetalleEnvio= new List<EnvioDetalle>();
        this.Visible = true;
        this.Estado = ESTADOENVIO.PENDIENTE.ToString();

    }

}

public class EnvioDetalle
{
    [Key]
    public int DetalleId  { get; set; }

    public int PedidoId {get; set;}

    public int ArticuloId {get; set;}

    public int Cantidad {get; set;}

    public double Peso {get; set;}

    public double? Peso_Total {

        get  {return Cantidad * Peso;}

    }


}
public enum ESTADOENVIO{

    PENDIENTE,

    EMPACADO,

    ENCAMINO,

    RECIBIDO,

    LIQUIDADO






}

public enum CONDICION
{
    FRAGIL,

    NORMAL,



}


