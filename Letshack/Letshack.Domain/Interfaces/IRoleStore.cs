using Letshack.Domain.Models;

namespace Letshack.Domain.Interfaces;

public interface IRoleStore
{
    public Task Create(Role role);
    public Task Update(Role role);
    public Task Delete(int id);
    public Task<IReadOnlyList<Role>> GetAll();
    public Task<Role> Get(int id);
}