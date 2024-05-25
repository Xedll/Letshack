namespace Letshack.Domain.Models;

public class Technology
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public List<Tag> Tags { get; set; } = [];
}