namespace Letshack.WebAPI.Contracts;

public record AuthResponse(string Token, ManageProfileResponse ProfileInfo);