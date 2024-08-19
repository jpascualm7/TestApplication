namespace TestApplication.Application.Common.Exceptions;

public class NotFoundDetailsException : Exception
{
    public NotFoundDetailsException(string message) : base(message)
    {
    }
}
