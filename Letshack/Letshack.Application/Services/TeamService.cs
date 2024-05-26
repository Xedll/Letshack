using Letshack.Domain.Interfaces;
using Letshack.Domain.Models;

namespace Letshack.Application.Services;

public class TeamService
{
    private readonly ITeamStore _teamStore;
    private readonly IRoleStore _roleStore;
    private readonly INeededRoleStore _neededRoleStore;

    public TeamService(ITeamStore teamStore, IRoleStore roleStore, INeededRoleStore neededRoleStore)
    {
        _teamStore = teamStore;
        _roleStore = roleStore;
        _neededRoleStore = neededRoleStore;
    }

    public async Task<bool> Create(Team team, List<int> neededRoles)
    {
        if (!await _roleStore.CheckForAll(neededRoles)) return false;
        await _teamStore.Create(team);
        await _neededRoleStore.AddAll(neededRoles.Select(n => new NeededRole
        {
            RoleId = n,
            TeamId = team.Id
        }).ToList());
        return true;
    }

    public async Task<bool> UpdateTeam(int teamId, string userId, string title, string description, List<int> neededRoles)
    {
        var team = await _teamStore.GetById(teamId);
        if (team is null) return false;
        if (team.CreatorId != userId) return false;

        if (!await _roleStore.CheckForAll(neededRoles)) return false;
        await _neededRoleStore.DeleteByTeamId(teamId);
        await _neededRoleStore.AddAll(neededRoles.Select(n => new NeededRole
        {
            TeamId = teamId,
            RoleId = n
        }).ToList());
        await _teamStore.Update(new Team
        {
            Id = team.Id,
            Description = description,
            Title = title
        });
        return true;
    }

    public async Task<IReadOnlyList<Team>> GetAll()
    {
        return await _teamStore.Get();
    }

    public async Task<Team?> GetById(int id)
    {
        return await _teamStore.GetById(id);
    }
}