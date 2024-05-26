using Letshack.Domain.Models;

namespace Letshack.Domain.Interfaces;

public interface IUserStore
{
    public Task<IReadOnlyList<User>> GetAll();
    public Task<User> GetById(string userId);
    public Task Update(User user);
}