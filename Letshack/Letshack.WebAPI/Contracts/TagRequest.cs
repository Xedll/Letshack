using System.ComponentModel.DataAnnotations;

namespace Letshack.WebAPI.Contracts;

public record TagRequest(
    [Required, Range(1, 1000)] int RelatedTopicId,
    [Required, Range(1, 1000)] int TechnologyId
    );