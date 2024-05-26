using System.ComponentModel.DataAnnotations;

namespace Letshack.WebAPI.Contracts;

public record TeamRequest(
    [Required] string Title,
    [Required] string Description,
    [Required] List<int> NeededRoles
    );