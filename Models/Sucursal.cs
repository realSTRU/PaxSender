using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

public class Sucursal{


    [Key]
    public int SucursalId { get; set; }
    
    public string? Nombre { get; set; }

    public string? Direccion {get; set;}
    public DateTime Fecha_Registro {get; set;}
    public bool Visible { get; set; }


    public Sucursal()
    {
        Visible = true;
        Fecha_Registro = DateTime.Now;
    }

}
