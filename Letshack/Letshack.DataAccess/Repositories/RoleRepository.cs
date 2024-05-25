using Letshack.Domain.Exceptions;
using Letshack.Domain.Interfaces;
using Letshack.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Letshack.DataAccess.Repositories;

public class RoleRepository : IRoleStore
{
    private readonly AppDbContext _context;

    public RoleRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task Create(Role role)
    {
        await _context.TeamRole.AddAsync(role);
    }

    public async Task Update(Role role)
    {
        await _context.TeamRole
            .Where(r => r.Id == role.Id)
            .ExecuteUpdateAsync(r => r
                .SetProperty(ro => ro.Title, role.Title));
    }

    public async Task Delete(int id)
    {
        await _context.TeamRole.
            Where(r => r.Id == id)
            .ExecuteDeleteAsync();
    }

    public async Task<IReadOnlyList<Role>> GetAll()
    {
       return await _context.TeamRole.
            AsNoTracking()
            .ToListAsync();
    }

    public async Task<Role> Get(int id)
    {
        return await _context.TeamRole.FirstOrDefaultAsync(r => r.Id == id)
               ?? throw new NotFoundException($"role with id: {id} not found");
    }
}