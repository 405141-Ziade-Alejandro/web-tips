using System.ComponentModel.DataAnnotations.Schema;

namespace FinalAnterior.Models;
[Table("Provincias")]
public class Provincia
{
    public Guid Id { get; set; }
    public string Nombre { get; set; }
}