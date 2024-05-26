using System.ComponentModel.DataAnnotations;

namespace Letshack.WebAPI.Contracts;

public record AuthRequest([Required] string Login, [Required] string Password);