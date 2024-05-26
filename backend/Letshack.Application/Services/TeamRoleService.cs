using Letshack.Domain.Interfaces;
using Letshack.Domain.Models;

namespace Letshack.Application.Services;

public class TeamRoleService
{
    private readonly IRoleStore _store;

    public TeamRoleService(IRoleStore store)
    {
        _store = store;
    }

    public async Task<IReadOnlyList<Role>> GetAllTeamRoles()
    {
        return await _store.GetAll();
    }

    public async Task<Role> GetTeamRoleById(int id)
    {
        return await _store.Get(id);
    }

    public async Task CreateTeamRole(Role role)
    {
        await _store.Create(role);
    }

    public async Task DeleteTeamRole(int id)
    {
        await _store.Delete(id);
    }

    public async Task UpdateTeamRole(Role role)
    {
        await _store.Update(role);
    }
}