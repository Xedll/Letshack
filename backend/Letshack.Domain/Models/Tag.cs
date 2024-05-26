namespace Letshack.Domain.Models;

public class Tag
{
    public int Id { get; set; }
    public int RelatedTopicId { get; set; }
    public RelatedTopic RelatedTopic { get; set; }
    public int TechnologyId { get; set; }
    public Technology Technology { get; set; } 
}