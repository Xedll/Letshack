namespace Letshack.Domain.Models;

public class RelatedTopic
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public List<Tag> Tags { get; set; } = [];
}