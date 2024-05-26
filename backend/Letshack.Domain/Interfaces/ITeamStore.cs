using Letshack.Domain.Models;

namespace Letshack.Domain.Interfaces;

public interface ITeamStore
{
    public Task Create(Team team);
    public Task<IReadOnlyList<Team>> Get();
    public Task<Team?> GetById(int id);
    public Task Update(Team team);
}