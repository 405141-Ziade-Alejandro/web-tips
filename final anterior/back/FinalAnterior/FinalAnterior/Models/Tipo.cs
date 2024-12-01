using System.ComponentModel.DataAnnotations.Schema;

namespace FinalAnterior.Models;
[Table("Tipos")]
public class Tipo
{
    public Guid Id { get; set; }
    public string Nombre { get; set; }
}