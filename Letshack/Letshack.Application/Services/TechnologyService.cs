using Letshack.Domain.Interfaces;
using Letshack.Domain.Models;

namespace Letshack.Application.Services;

public class TechnologyService
{
    private readonly ITechnologyStore _technologyStore;

    public TechnologyService(ITechnologyStore technologyStore)
    {
        _technologyStore = technologyStore;
    }

    public async Task<IReadOnlyList<Technology>> GetAllTechnologies()
    {
        return await _technologyStore.GetAll();
    }

    public async Task CreateTechnology(Technology technology)
    {
        await _technologyStore.Create(technology);
    }

    public async Task<Technology> GetById(int id)
    {
        return await _technologyStore.Get(id);
    }

    public async Task DeleteById(int id)
    {
        await _technologyStore.Delete(id);
    }

    public async Task UpdateTechnology(Technology technology)
    {
        await _technologyStore.Update(technology);
    }
}