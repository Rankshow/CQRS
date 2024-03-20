using System.Text.Json;

namespace CQRS.Wrappers;

public class Response<T>
{
    public Response()
    {
        
    }
    public Response(T data, string message, string code)
    {
        Data = data;    
        Message = message;
        Code = code;
    }
    public Response(T data)
    {
        Data = data; 
    }
    public Response(string message, string code)
    {
        
        Message = message;
        Code = code;
    }
    public bool Succeeded { get; set; }
    public string Message { get; set; }
    public IDictionary<string, string[]> Errors { get; set; } = new Dictionary<string, string[]>();
    public T? Data { get; set; }
    public string Code { get; set; }
    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}
