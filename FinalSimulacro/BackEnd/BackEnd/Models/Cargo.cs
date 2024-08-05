using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Models;
[Table("cargos")]
public class Cargo
{
    public Guid Id { get; set; }
    public string Nombre  { get; set; }
}