using System.ComponentModel.DataAnnotations;

namespace Letshack.WebAPI.Contracts;

public record RelatedTopicRequest([Required] string Title);

public record RelatedTopicResponse(int Id, string Title);