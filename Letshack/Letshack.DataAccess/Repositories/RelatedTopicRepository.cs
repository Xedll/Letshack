using Letshack.Domain.Exceptions;
using Letshack.Domain.Interfaces;
using Letshack.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Letshack.DataAccess.Repositories;

public class RelatedTopicRepository : IRelatedTopicStore
{
    private readonly AppDbContext _context;

    public RelatedTopicRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<IReadOnlyList<RelatedTopic>> GetAll()
    {
        return await _context.RelatedTopic
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task Create(RelatedTopic relatedTopic)
    {
        await _context.RelatedTopic.AddAsync(relatedTopic);
        await _context.SaveChangesAsync();
    }

    public async Task Update(RelatedTopic relatedTopic)
    {
        await _context.RelatedTopic
            .Where(r => r.Id == relatedTopic.Id)
            .ExecuteUpdateAsync(r => r
                .SetProperty(re => re.Title, relatedTopic.Title));
    }

    public async Task Delete(int id)
    {
        await _context.RelatedTopic.Where(r => r.Id == id).ExecuteDeleteAsync();
    }

    public async Task<RelatedTopic> Get(int id)
    {
        return await _context.RelatedTopic
            .AsNoTracking()
            .FirstOrDefaultAsync(r => r.Id == id)
               ?? throw new NotFoundException($"related topic with id: {id} not found");
    }
}