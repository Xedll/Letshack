namespace Letshack.Domain.Models;

public class TeamMember
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public int TeamId { get; set; }
    public Team Team { get; set; }
    public string Description { get; set; } = string.Empty;
}