namespace Letshack.Domain.Models;

public class UserTag
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public int TagId { get; set; }
    public Tag Tag { get; set; }
}