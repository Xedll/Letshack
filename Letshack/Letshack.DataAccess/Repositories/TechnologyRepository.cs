using Letshack.Domain.Exceptions;
using Letshack.Domain.Interfaces;
using Letshack.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Letshack.DataAccess.Repositories;

public class TechnologyRepository : ITechnologyStore
{
    private readonly AppDbContext _context;

    public TechnologyRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<IReadOnlyList<Technology>> GetAll()
    {
        return await _context.Technology
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task Create(Technology technology)
    {
        await _context.Technology.AddAsync(technology);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Technology technology)
    {
        await _context.Technology
            .Where(r => r.Id == technology.Id)
            .ExecuteUpdateAsync(r => r
                .SetProperty(re => re.Title, technology.Title));
    }

    public async Task Delete(int id)
    {
        await _context.Technology.Where(r => r.Id == id).ExecuteDeleteAsync();
    }

    public async Task<bool> CheckForAll(List<int> technologyIds)
    {
        var technologies = await _context.Technology.Select(t => t.Id).ToListAsync();
        return technologyIds.All(t => technologies.Contains(t));
    }

    public async Task<Technology> Get(int id)
    {
        return await _context.Technology
                   .AsNoTracking()
                   .FirstOrDefaultAsync(r => r.Id == id)
               ?? throw new NotFoundException($"technology with id: {id} not found");
    }

    public async Task<IReadOnlyList<Technology>> GetAllUserTechnology(string userId)
    {
       return await _context.UserTechnology
            .AsNoTracking()
            .Where(ut => ut.UserId == userId)
            .Include(ut => ut.Technology)
            .Select(ut => new Technology
            {
                Id = ut.Id,
                Title = ut.Technology.Title
            }).ToListAsync();
    }
}