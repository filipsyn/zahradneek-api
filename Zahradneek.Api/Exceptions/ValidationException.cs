namespace Zahradneek.Api.Exceptions;

public class ValidationException: Exception
{
    public ValidationException(string message): base(message)
    { 
    }
}