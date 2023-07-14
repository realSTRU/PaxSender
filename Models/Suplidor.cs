using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PaxSender.Models
{
public class Suplidor
{
    [Key]
    public int SuplidorId { get; set; }

    public string? Nombre { get; set; }

    public string? Telefono { get; set; }

    public string? Celular { get; set; }

    public string? Direccion {get; set;}

    public string? RNC {get; set;}

    public string? Correo {get; set;}

    public DateTime Fecha_Registro {get; set;}

    public bool Visible {get; set;}

    public Suplidor()
    {
        this.Visible = true;
        this.Fecha_Registro = DateTime.Now;
    }






}
}
