namespace BackEnd.Dto;

public class EmpleadoAltaDto
{
    public string Nombre  { get; set; }
    public string Apellido  { get; set; }
    
    public Guid IdCargo  { get; set; }
    
    public Guid IdSucursal  { get; set; }
    public string Dni  { get; set; }

    public string Jefe { get; set; }
}