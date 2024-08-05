namespace BackEnd.Dto;

public class EmpleadoDto
{
    public string Nombre  { get; set; }
    public string Apellido  { get; set; }
    
    public string Cargo  { get; set; }//falta
    
    public string Sucursal  { get; set; } // falta
    public string Ciudad { get; set; }//falta
    public string Dni  { get; set; }
    public DateTime FechaAlta  { get; set; }
    public string Jefe { get; set; }
}