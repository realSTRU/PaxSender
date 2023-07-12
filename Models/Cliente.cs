using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

public class Cliente
{
    [Key]
    public int ClienteId { get; set; }

    public string? Nombre { get; set; }

    public string? Celular { get; set; }

    public string? Telefono { get; set; }

    public string Direccion {get; set;}

    public string? Cedula {get; set;}

    public string? Correo {get; set;}

    public string? RNC {get; set;}

    public DateTime Fecha_Registro {get; set;}

    public bool Visible {get; set;}

    public Cliente()
    {
        this.Visible = true;
        this.Fecha_Registro = DateTime.Now;
    }


}   