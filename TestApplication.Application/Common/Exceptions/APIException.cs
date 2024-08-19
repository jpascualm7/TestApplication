namespace TestApplication.Application.Common.Exceptions;

public class APIException : Exception
{
    public APIException(string message, string statusCode, string reasonPhrase, string errorDetail) : base($"{message}. Status Code: {statusCode}. ReasonPhrase: {reasonPhrase}. Detail: {errorDetail}")
    {
    }

    public APIException(string message, string statusCode, string reasonPhrase) : base($"{message}. Status Code: {statusCode}. ReasonPhrase: {reasonPhrase}")
    {
    }
    public APIException(string message) : base(message)
    {
    }
}
