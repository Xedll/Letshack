using Letshack.Domain.Models;

namespace Letshack.Domain.Interfaces;

public interface IRelatedTopicStore
{
    public Task<IReadOnlyList<RelatedTopic>> GetAll();
    public Task Create(RelatedTopic relatedTopic);
    public Task Update(RelatedTopic relatedTopic);
    public Task Delete(int id);
    public Task<RelatedTopic> Get(int id);
}