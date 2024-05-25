using Microsoft.AspNetCore.Identity;

namespace Letshack.Domain.Models;

public class User : IdentityUser<Guid>
{
    public string? TgId { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsVisible { get; set; } = false;
    public List<Team> Teams { get; set; } = [];
    public List<TeamMember> TeamMembers { get; set; } = [];
    public List<UserTechnology> UserTechnologies { get; set; }
}