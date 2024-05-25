namespace Letshack.WebAPI.Contracts;

public record TechnologyTagResponse(int Id, string Title, List<RelatedTopicResponse> RelatedTopics);