using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Models;
[Table("empleados")]
public class Empleado
{
    public Guid Id  { get; set; }
    public string Nombre  { get; set; }
    public string Apellido  { get; set; }
    
    public Guid IdCargo  { get; set; }
    [ForeignKey("IdCargo")] Cargo Cargo  { get; set; }
    
    public Guid IdSucursal  { get; set; }
    public string Dni  { get; set; }
    public DateTime FechaAlta  { get; set; }
    public string Jefe { get; set; }
}