namespace Backend.Transfer.Messages;

public class RespMessage
{
    public bool Success { get; set; }
    
    public string Message { get; set; }
    
    public RespMessage(bool success, string message)
    {
        Success = success;
        Message = message;
    }
}