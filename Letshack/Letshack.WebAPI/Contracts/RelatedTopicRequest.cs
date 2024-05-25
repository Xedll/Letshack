using System.ComponentModel.DataAnnotations;

namespace Letshack.WebAPI.Contracts;

public record RelatedTopicRequest([Required] string Title);