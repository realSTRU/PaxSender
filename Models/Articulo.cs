using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;


public class Articulo
{
    [Key]
    
    public int ArticuloId { get; set; }

    public int SuplidorId { get; set; }

    public int CategoriaId { get; set; }

    public string? Descripcion { get; set; }

    public double Costo { get; set; }

    public double Precio { get; set; }

    public int Existencia  {get; set;}

    public string Estado {get; set;}

    public int Num_Reorden {get; set;}

    public DateTime Fecha_Entrada { get; set; }
    public DateTime Fecha_Caducidad { get; set; }

    public bool Visible {get; set;}

    public Articulo()
    {
        this.Existencia=0;
        this.Visible = true;
        this.Estado = ESTADOS.ACTIVO.ToString();
        this.Num_Reorden=10;
        this.Fecha_Entrada= DateTime.Now;
    }

    public enum ESTADOS
    {
        ACTIVO,

        DESHABILITADO,

        REORDEN,

        PERECEDERO
    }








}