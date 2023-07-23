using System.ComponentModel.DataAnnotations;
namespace PaxSender
{
public class Movimiento
{
    [Key]
    public int OrdenID { get; set; }
    public int ArticuloId { get; set; }
    public int? Cantidad { get; set; }
    public int? cantidad_anterior { get; set; }
    public int? cantidad_Resultante {get; set;}
    public string? Razon { get; set; }
    public DateTime? Fecha { get; set; }
    public bool Visible { get; set; }

    public Movimiento ()
    {
        this.Cantidad =0;
        this.Visible = true;
        this.Fecha= DateTime.Now;
    }
}
    public class Entrada : Movimiento
    {
        
    }
        public class Salida: Movimiento
    {
        
    }
}