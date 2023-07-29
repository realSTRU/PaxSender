using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

public class Almacen
{
    [Key]
    public int AlmacenId { get; set; }

    public string Identificador { get; set; }

    public bool Visible {get; set;}

    public Almacen()
    {
        this.Identificador = String.Empty;
        this.Visible = true;
    }
}