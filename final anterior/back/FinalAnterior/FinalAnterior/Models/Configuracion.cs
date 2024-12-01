using System.ComponentModel.DataAnnotations.Schema;

namespace FinalAnterior.Models;
[Table("Configuraciones")]
public class Configuracion
{
    public Guid Id { get; set; }
    public string Nombre { get; set; }
    public string Valor { get; set; }
}