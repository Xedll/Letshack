using System.ComponentModel.DataAnnotations;

namespace Letshack.WebAPI.Contracts;

public record CheckBoxRequest([Required] bool IsVisible);