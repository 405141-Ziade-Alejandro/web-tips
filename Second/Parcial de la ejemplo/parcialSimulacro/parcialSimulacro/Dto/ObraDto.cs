﻿namespace parcialSimulacro.Dto;

public class ObraDto
{
    public Guid Id { get; set; }
    
    public string Nombre { get; set; } = null!;

    public string DatosVarios { get; set; } = null!;
    
    public string NombreTipoObra { get; set; } = null!;

    public int CantAlbaniles { get; set; }
}