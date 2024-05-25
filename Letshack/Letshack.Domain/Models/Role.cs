namespace Letshack.Domain.Models;

public class Role
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public List<NeededRole> NeededRoles { get; set; } = [];
}