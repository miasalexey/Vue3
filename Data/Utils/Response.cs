namespace Data.Utils;

public class Response<T>
{
    public bool IsCompleted { get; set; } = true;
    public T? Data { get; set; } = default;
}