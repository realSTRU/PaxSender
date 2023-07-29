
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaxSender.Models
{

    public class Venta
    {

        [Key]
        public int VentaId { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Now;

        public int SuplidorId { get; set; }

        public double? Total { get; set; } = 0;

        public bool Visible { get; set; } = true;
        
        [ForeignKey("CompraId")]
        public List<VentaDetalle> DetalleVenta { get; set; } = new List<VentaDetalle>();



    }

    public class VentaDetalle
    {
        [Key]
        public int DetalleId { get; set; }
        public int CompraId { get; set; }
        public int ArticuloId { get; set; }
        public int Cantidad { get; set; }
        public double? Precio { get; set; }
        public bool Visible { get; set; }
        [NotMapped]
        public double? Importe
        {
            get { return Cantidad * Precio; }
        }

    }

}




