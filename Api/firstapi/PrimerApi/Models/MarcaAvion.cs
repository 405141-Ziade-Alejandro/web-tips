using System.ComponentModel.DataAnnotations.Schema;

namespace PrimerApi.Models;
[Table("marcas_aviones")]
public class MarcaAvion
{
    public Guid Id { get; set; }
    public string Nombre { get; set; }
    public DateTime FechaAlta { get; set; }
}