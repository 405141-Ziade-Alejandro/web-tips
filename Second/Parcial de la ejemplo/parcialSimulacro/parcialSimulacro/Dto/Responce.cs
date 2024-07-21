namespace parcialSimulacro.Dto;

public class Responce<T>
{
    public bool Success { get; set; }
    public T? Data { get; set; }
    public string? message { get; set; }
}