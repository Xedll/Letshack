using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Letshack.WebAPI.Contracts;

public record ProfileRequest(    
    [Required] string Initials,
    [Required] string Description,
    [ValidateNever][EmailAddress] string? Email,
    [ValidateNever][Phone] string? Number,
    [ValidateNever] string? TgId,
    [Required] bool IsVisible,
    [Required] List<int> TechnologiesList
);