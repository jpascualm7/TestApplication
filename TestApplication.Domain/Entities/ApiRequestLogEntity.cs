namespace TestApplication.Domain.Entities;

/// <summary>
/// Entity to save all the API requests and responses
/// </summary>
public class ApiRequestLogEntity
{
    /// <summary>
    /// API Request Id
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// API Id
    /// </summary>
    public int ApiId { get; set; }

    /// <summary>
    /// Request Date
    /// </summary>
    public DateTime RequestDateTimeUtc { get; set; }

    /// <summary>
    /// Request Method
    /// </summary>
    public string? RequestMethod { get; set; }

    /// <summary>
    /// Request Path
    /// </summary>
    public string? RequestPath { get; set; }

    /// <summary>
    /// Request Query
    /// </summary>
    public string? RequestQuery { get; set; }

    /// <summary>
    /// Request Body
    /// </summary>
    public string? RequestBody { get; set; }

    /// <summary>
    /// Request Scheme
    /// </summary>
    public string? RequestScheme { get; set; }

    /// <summary>
    /// Request Host
    /// </summary>
    public string? RequestHost { get; set; }

    /// <summary>
    /// Request Content Type
    /// </summary>
    public string? RequestContentType { get; set; }

    /// <summary>
    /// Response Content Type
    /// </summary>
    public string? ResponseContentType { get; set; }

    /// <summary>
    /// Response Status
    /// </summary>
    public string? ResponseStatus { get; set; }

    /// <summary>
    /// Response Body
    /// </summary>
    public string? ResponseBody { get; set; }

    /// <summary>
    /// Response Date TimeUtc
    /// </summary>
    public DateTime ResponseDateTimeUtc { get; set; }
}
