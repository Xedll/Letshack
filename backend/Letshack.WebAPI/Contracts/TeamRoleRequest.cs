using System.ComponentModel.DataAnnotations;

namespace Letshack.WebAPI.Contracts;

public record TeamRoleRequest([Required] string Title);