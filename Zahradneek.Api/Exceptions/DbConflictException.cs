namespace Zahradneek.Api.Exceptions;

public class DbConflictException : Exception
{
    public DbConflictException() : base("Conflict occured while adding to database")
    {
    }
}