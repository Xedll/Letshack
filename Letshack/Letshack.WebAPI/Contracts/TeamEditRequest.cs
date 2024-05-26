using System.ComponentModel.DataAnnotations;

namespace Letshack.WebAPI.Contracts;

public record TeamEditRequest(
       [Required] string Title,
       [Required] string Description,
       [Required] List<int> NeededRoles
    );