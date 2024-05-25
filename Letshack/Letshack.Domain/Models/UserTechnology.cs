namespace Letshack.Domain.Models;

public class UserTechnology
{
    public int Id { get; set; }
    public int TechnologyId { get; set; }
    public Technology Technology { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
}