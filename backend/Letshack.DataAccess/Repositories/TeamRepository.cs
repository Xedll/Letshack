using Letshack.Domain.Interfaces;
using Letshack.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Letshack.DataAccess.Repositories;

public class TeamRepository : ITeamStore
{
    private readonly AppDbContext _context;

    public TeamRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task Create(Team team)
    {
        await _context.Team.AddAsync(team);
        await _context.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<Team>> Get()
    {
        return await _context.Team
            .Include(t => t.Creator)
            .Include(r => r.NeededRoles)
            .ThenInclude(re => re.Role)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Team?> GetById(int id)
    {
        return await _context.Team
            .Include(t => t.Creator)
            .Include(r => r.NeededRoles)
            .ThenInclude(re => re.Role)
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task Update(Team team)
    {
        await _context.Team
            .Where(t => t.Id == team.Id)
            .ExecuteUpdateAsync(t => t
                .SetProperty(te => te.Description ,team.Description)
                .SetProperty(te => te.Title ,team.Title));
    }
    
}