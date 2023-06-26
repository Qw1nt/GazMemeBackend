namespace Domain.Entities;

public class User : EntityBase
{
    public string Login { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string PasswordSalt { get; set; } = null!;
}