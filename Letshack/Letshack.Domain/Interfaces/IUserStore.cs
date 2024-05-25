using Letshack.Domain.Models;

namespace Letshack.Domain.Interfaces;

public interface IUserStore
{
    public Task<User> Get(Guid userId);
    public Task<IReadOnlyList<User>> GetAll();
}