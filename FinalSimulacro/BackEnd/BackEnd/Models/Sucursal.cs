using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Models;
[Table("sucursales")]
public class Sucursal
{
    public Guid Id  { get; set; }
    public string Nombre  { get; set; }
    
    public Guid IdCiudad  { get; set; }
    [ForeignKey("IdCiudad")] Ciudad Ciudad  { get; set; }
}