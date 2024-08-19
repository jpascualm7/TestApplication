namespace TestApplication.Domain.Entities;

/// <summary>
/// Finantial Institution Entity
/// </summary>
public class InstitutionEntity
{
    /// <summary>
    /// Institution Id
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Unique identifier for the institution in Plaid
    /// </summary>
    public string? InstitutionId { get; set; }

    /// <summary>
    /// The official name of the institution.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Indicates that the institution has an OAuth login flow. This will be true if OAuth is supported for any Items associated with the institution, even if the institution also supports non-OAuth connections.
    /// </summary>
    public bool Oauth { get; set; }

    /// <summary>
    /// The URL for the institution's website
    /// </summary>
    public string? Url { get; set; }

    /// <summary>
    /// Hexadecimal representation of the primary color used by the institution
    /// </summary>
    public string? PrimaryColor { get; set; }

    /// <summary>
    /// Base64 encoded representation of the institution's logo, returned as a base64 encoded 152x152 PNG. Not all institutions' logos are available.
    /// </summary>
    public byte[]? Logo { get; set; }

    /// <summary>
    /// Created By
    /// </summary>
    public string? CreatedBy { get; set; }

    /// <summary>
    /// Created Date
    /// </summary>
    public DateTime CreatedDateTimeUtc { get; set; }

    /// <summary>
    /// Last Updated By
    /// </summary>
    public string? UpdatedBy { get; set; }

    /// <summary>
    /// Last Updated Date
    /// </summary>
    public DateTime UpdatedDateTimeUtc { get; set; }
}
