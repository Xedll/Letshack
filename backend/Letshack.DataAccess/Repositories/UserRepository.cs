using Letshack.Domain.Exceptions;
using Letshack.Domain.Interfaces;
using Letshack.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Letshack.DataAccess.Repositories;

public class UserRepository : IUserStore
{
    private readonly AppDbContext _dbContext;

    public UserRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IReadOnlyList<User>> GetAll()
    {
        return await _dbContext.Users
            .Include(u => u.Teams)
            .Include(u => u.UserTechnologies)
            .ThenInclude(ut => ut.Technology)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<User?> GetById(string userId)
    {
        return await _dbContext.Users
                   .Include(u => u.Teams)
                   .Include(u => u.UserTechnologies)
                   .ThenInclude(ut => ut.Technology)
                   .AsNoTracking()
                   .FirstOrDefaultAsync(u => u.Id == userId);
    }

    public async Task<User?> GetByLogin(string userLogin)
    {
        return await _dbContext.Users
            .Include(u => u.Teams)
            .Include(u => u.UserTechnologies)
            .ThenInclude(ut => ut.Technology)
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.UserName == userLogin);
    }

    public async Task Update(User user)
    {
        await _dbContext
            .Users.Where(u => u.Id == user.Id)
            .ExecuteUpdateAsync(u => u
                .SetProperty(ur => ur.UserTechnologies, user.UserTechnologies)
                .SetProperty(ur => ur.Description, user.Description)
                .SetProperty(ur => ur.TgId, user.TgId)
                .SetProperty(ur => ur.Email, user.Email)
                .SetProperty(ur => ur.IsVisible, user.IsVisible));
    }
}