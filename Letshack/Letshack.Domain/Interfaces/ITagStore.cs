using Letshack.Domain.Models;

namespace Letshack.Domain.Interfaces;

public interface ITagStore
{
    public Task<IReadOnlyList<Tag>> GetAll();
    public Task<IReadOnlyList<Tag>> GetAllWithTopic(int topicId);
    public Task<IReadOnlyList<Tag>> GetAllWithTechnology(int technologyId);
    public Task Create(Tag tag);
    public Task Update(Tag tag);
    public Task Delete(int id);
    public Task<Tag> GetById(int id);
}