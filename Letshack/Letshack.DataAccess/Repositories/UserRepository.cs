using System.Globalization;
using Letshack.Domain.Exceptions;
using Letshack.Domain.Interfaces;
using Letshack.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Letshack.DataAccess.Repositories;

public class UserRepository : IUserStore
{
    private readonly AppDbContext _dbContext;

    public UserRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User> Get(Guid userId)
    {
        return await _dbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u => u.Id == userId) 
               ?? throw new NotFoundException($"user with id: {userId} not found");
    }

    public async Task<IReadOnlyList<User>> GetAll()
    {
        return await _dbContext.Users
            .AsNoTracking()
            .ToListAsync();
    }
}