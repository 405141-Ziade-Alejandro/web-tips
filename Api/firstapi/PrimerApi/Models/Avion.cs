using System.ComponentModel.DataAnnotations.Schema;

namespace PrimerApi.Models;
[Table("Aviones")]
public class Avion
{
    public Guid Id { get; set; }
    public string Modelo { get; set; }
    public int CantidadPasageros { get; set; }
    public DateTime FechaAlta { get; set; }

    public Guid IdMarca { get; set; }
    [ForeignKey("IdMarca")] public MarcaAvion MarcaAvion { get; set; }
}