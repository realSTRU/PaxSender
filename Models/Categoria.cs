using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

public class Categoria
{
    [Key]
    public int CategoriaId { get; set; }

    public string Descripcion { get; set; }

    public bool Visible {get; set;}

    public Categoria()
    {
        this.Visible = true;
    }
}