using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Models;
[Table("ciudades")]
public class Ciudad
{
    public Guid Id  { get; set; }
    public string Nombre  { get; set; }
}