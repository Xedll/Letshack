using Letshack.Domain.Models;

namespace Letshack.Domain.Interfaces;

public interface IUserTechnologyStore
{
    public Task DeleteByUserId(string userId);
    public Task AddAll(List<UserTechnology> userTechnologies);
}