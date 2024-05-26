using Letshack.Domain.Interfaces;
using Letshack.Domain.Models;

namespace Letshack.Application.Services;

public class TagService
{
    private readonly ITagStore _tagStore;

    public TagService(ITagStore tagStore)
    {
        _tagStore = tagStore;
    }

    public async Task<IReadOnlyList<Tag>> GetAllTags()
    {
        return await _tagStore.GetAll();
    }

    public async Task CreateTag(Tag tag)
    {
        await _tagStore.Create(tag);
    }

    public async Task<IReadOnlyList<Tag>> GetAllTechnologyTags(int technologyId)
    {
        return await _tagStore.GetAllWithTechnology(technologyId);
    }

    public async Task<IReadOnlyList<Tag>> GetAllTopicsTags(int topicId)
    {
        return await _tagStore.GetAllWithTopic(topicId);
    }

    public async Task DeleteById(int id)
    {
        await _tagStore.Delete(id);
    }
}