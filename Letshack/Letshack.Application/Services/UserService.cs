using Letshack.Domain.Exceptions;
using Letshack.Domain.Interfaces;
using Letshack.Domain.Models;

namespace Letshack.Application.Services;

public class UserService
{
    private readonly ITechnologyStore _technologyStore;
    private readonly IUserStore _userStore;
    private readonly IUserTechnologyStore _userTechnologyStore;

    public UserService(ITechnologyStore technologyStore, IUserStore userStore, IUserTechnologyStore userTechnologyStore)
    {
        _technologyStore = technologyStore;
        _userStore = userStore;
        _userTechnologyStore = userTechnologyStore;
    }

    public async Task<IReadOnlyList<Technology>> GetUserTechnology(string userId)
    {
        return await _technologyStore.GetAllUserTechnology(userId);
    }

    public async Task UpdateUser(User user)
    {
        await _userStore.Update(user);
    }

    public async Task UpdateUserTechnologies(string userId, List<int> technologiesIds)
    {
        if (!await _technologyStore.CheckForAll(technologiesIds)) throw new InvalidTechnologyIdException();
        await _userTechnologyStore.DeleteByUserId(userId);
        await _userTechnologyStore.AddAll(technologiesIds.Select(t => new UserTechnology
        {
            TechnologyId = t,
            UserId = userId
        }).ToList());
    }
}