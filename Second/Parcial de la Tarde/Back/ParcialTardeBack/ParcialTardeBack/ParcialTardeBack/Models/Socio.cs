using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParcialTardeBack.Models;

[Table("Socios")]
public partial class Socio
{
    public Guid Id { get; set; }

    public string Nombre { get; set; }

    public string Apellido { get; set; }

    public int Dni { get; set; }

    public string? NombreDeporte { get; set; }

    public DateTime? FechaCreacion { get; set; }
}
