using System.ComponentModel.DataAnnotations;

namespace DataAccess.Database.Model;

public partial class UserInfo
{
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    [Key]
    public string Email { get; set; } = null!;

    public string? Address1 { get; set; }

    public string? Address2 { get; set; }

    public string? City { get; set; }

    public string? County { get; set; }

    public string? State { get; set; }

    public string? PostalCode { get; set; }
}
