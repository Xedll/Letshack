using Letshack.Domain.Exceptions;
using Letshack.Domain.Interfaces;
using Letshack.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Letshack.DataAccess.Repositories;

public class TagRepository : ITagStore
{
    private readonly AppDbContext _context;

    public TagRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<IReadOnlyList<Tag>> GetAll()
    {
        return await _context
            .Tag
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IReadOnlyList<Tag>> GetAllWithTopic(int topicId)
    {
        return await _context
            .Tag
            .Where(t => t.RelatedTopicId == topicId)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IReadOnlyList<Tag>> GetAllWithTechnology(int technologyId)
    {
        return await _context
            .Tag
            .Where(t => t.TechnologyId == technologyId)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task Create(Tag tag)
    {
        await _context.Tag.AddAsync(tag);
        await _context.SaveChangesAsync();
    }

    public async Task Update(Tag tag)
    {
        await _context.Tag.Where(t => t.Id == tag.Id).ExecuteUpdateAsync(t => t
            .SetProperty(ta => ta.TechnologyId, tag.TechnologyId)
            .SetProperty(ta => ta.RelatedTopicId, tag.RelatedTopicId));
    }

    public async Task Delete(int id)
    {
        await _context.Tag
            .Where(t => t.Id == id)
            .ExecuteDeleteAsync();
    }

    public async Task<Tag> GetById(int id)
    {
        return await _context.Tag
                   .AsNoTracking()
                   .FirstOrDefaultAsync(t => t.Id == id)
               ?? throw new NotFoundException($"tag with id: {id} not found");
    }
}