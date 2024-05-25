using Microsoft.AspNetCore.Identity;

namespace Letshack.Domain.Models;

public class User : IdentityUser<Guid>
{
    public string? TgId { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}