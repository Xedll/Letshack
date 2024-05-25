namespace Letshack.Domain.Models;

public class NeededRole
{
    public int Id { get; set; }
    public int TeamId { get; set; }
    public Team Team { get; set; }
    public int RoleId { get; set; }
    public Role Role { get; set; }
}