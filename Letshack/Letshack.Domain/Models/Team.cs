namespace Letshack.Domain.Models;

public class Team
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string CreatorId { get; set; }
    public User Creator { get; set; }
    public List<TeamMember> TeamMembers { get; set; } = [];
}