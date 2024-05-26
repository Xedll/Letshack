using Letshack.Domain.Models;

namespace Letshack.Domain.Interfaces;

public interface ITechnologyStore
{
    public Task<IReadOnlyList<Technology>> GetAll();
    public Task Create(Technology relatedTopic);
    public Task Update(Technology relatedTopic);
    public Task Delete(int id);
    public Task<bool> CheckForAll(List<int> technologyIds);
    public Task<Technology> Get(int id);
    public Task<IReadOnlyList<Technology>> GetAllUserTechnology(string userId);
}