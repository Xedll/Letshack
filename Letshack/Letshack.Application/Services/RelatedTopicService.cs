using Letshack.Domain.Interfaces;
using Letshack.Domain.Models;

namespace Letshack.Application.Services;

public class RelatedTopicService
{
    private readonly IRelatedTopicStore _relatedTopicStore;

    public RelatedTopicService(IRelatedTopicStore relatedTopicStore)
    {
        _relatedTopicStore = relatedTopicStore;
    }

    public async Task<IReadOnlyList<RelatedTopic>> GetAllTopics()
    {
        return await _relatedTopicStore.GetAll();
    }

    public async Task<RelatedTopic> GetById(int id)
    {
        return await _relatedTopicStore.Get(id);
    }

    public async Task CreateRelatedTopic(RelatedTopic relatedTopic)
    {
        await _relatedTopicStore.Create(relatedTopic);
    }

    public async Task DeleteById(int id)
    {
        await _relatedTopicStore.Delete(id);
    }

    public async Task UpdateRelatedTopic(RelatedTopic relatedTopic)
    {
        await _relatedTopicStore.Update(relatedTopic);
    } 
}