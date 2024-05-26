using Letshack.Domain.Interfaces;
using Letshack.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Letshack.DataAccess.Repositories;

public class NeededRoleRepository : INeededRoleStore
{
    private readonly AppDbContext _context;

    public NeededRoleRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task DeleteByTeamId(int teamId)
    {
        await _context.NeededTeamRole
            .Where(n => n.TeamId == teamId)
            .ExecuteDeleteAsync();
    }

    public async Task AddAll(List<NeededRole> neededRoles)
    {
        await _context.NeededTeamRole.AddRangeAsync(neededRoles);
        await _context.SaveChangesAsync();
    }
}