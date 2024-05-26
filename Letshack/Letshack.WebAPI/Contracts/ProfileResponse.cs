namespace Letshack.WebAPI.Contracts;

public record ProfileResponse(
    string UserId,
    string Initials,
    string Description,
    string Email,
    string Number,
    string TgId,
    bool IsVisible,
    List<TechnologyResponse> Technologies
    );

public record ManageProfileResponse(
    string UserId,
    string Initials,
    string Description,
    string Email,
    string Number,
    string TgId,
    bool IsVisible,
    List<TechnologyResponse> Technologies,
    List<TeamHistory> CreatedTeams
);

    public record  TeamHistory(string Title, string Description);