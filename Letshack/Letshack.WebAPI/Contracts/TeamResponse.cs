namespace Letshack.WebAPI.Contracts;

public record TeamResponse(
    int Id, 
    TeamCreator TeamCreator, 
    string Title,
    string Description,
    DateTime CreatedAt,
    List<TeamMember> TeamMembers,
    List<TeamRole> NeededRoles
    );

public record TeamMember(int Id, string UserId, string Description);
public record TeamCreator(string Id, string Login, string TgId, string Number, string Email);