namespace BackEnd.Dto;

public class ResultadoBase<T>
{
    public bool Success { get; set; }
    public string? Message { get; set; }
    public T? Resultado { get; set; }
}