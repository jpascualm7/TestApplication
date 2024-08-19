namespace TestApplication.Domain.Entities;

/// <summary>
/// Account Entity
/// </summary>
public class AccountEntity
{
    /// <summary>
    /// Account Id
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// User Id
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// User
    /// </summary>
    public virtual UserEntity User { get; set; }

    /// <summary>
    /// Plaid API Public Token
    /// </summary>
    public string? PublicToken { get; set; }

    /// <summary>
    /// Plaid API Access Token
    /// </summary>
    public string? AccessToken { get; set; }

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
