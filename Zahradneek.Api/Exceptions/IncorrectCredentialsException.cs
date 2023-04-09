namespace Zahradneek.Api.Exceptions;

public class IncorrectCredentialsException : ValidationException
{
    public IncorrectCredentialsException() : base(message: "Incorrect credentials")
    {
    }
}