namespace Letshack.WebAPI.Contracts;

public record RelatedTopicTagResponse(
    int Id,
    string Title,
    List<TechnologyResponse> Technologies
    );