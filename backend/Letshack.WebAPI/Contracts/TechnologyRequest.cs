using System.ComponentModel.DataAnnotations;

namespace Letshack.WebAPI.Contracts;

public record TechnologyRequest([Required] string Title);