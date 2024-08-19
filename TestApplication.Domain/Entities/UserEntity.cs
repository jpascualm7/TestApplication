namespace TestApplication.Domain.Entities;

/// <summary>
/// User Entity
/// </summary>
public class UserEntity
{
    /// <summary>
    /// User Id
    /// </summary>
    public int Id { get; set; }

    public string? Email { get; set; }

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

    public virtual ICollection<AccountEntity> Accounts { get; set; } = new HashSet<AccountEntity>();
}
