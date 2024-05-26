using Letshack.Domain.Models;

namespace Letshack.Domain.Interfaces;

public interface INeededRoleStore
{
    public Task DeleteByTeamId(int teamId);
    public Task AddAll(List<NeededRole> neededRoles);
}