using Letshack.Domain.Interfaces;
using Letshack.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Letshack.DataAccess.Repositories;

public class UserTechnologyRepository : IUserTechnologyStore
{
    private readonly AppDbContext _dbContext;

    public UserTechnologyRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task DeleteByUserId(string userId)
    {
        await _dbContext.UserTechnology.Where(u => u.UserId == userId).ExecuteDeleteAsync();
    }

    public async Task AddAll(List<UserTechnology> userTechnologies)
    {
        await _dbContext.UserTechnology.AddRangeAsync(userTechnologies);
        await _dbContext.SaveChangesAsync();
    }
}