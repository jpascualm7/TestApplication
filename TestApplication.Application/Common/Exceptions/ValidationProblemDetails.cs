namespace TestApplication.Application.Common.Exceptions;

public class ValidationProblemDetails : Exception
{
    public IList<string> ValidationMessages { get; set; } = new List<string>();
    public ValidationProblemDetails(string message) : base(message)
    {
    }

    public ValidationProblemDetails(string message, IList<string> validationMessages) : base(message)
    {
        ValidationMessages = validationMessages;
    }

    public ValidationProblemDetails(string message, string validationMessages) : base(message)
    {
        ValidationMessages.Add(validationMessages);
    }

    public ValidationProblemDetails()
    {
    }
}
