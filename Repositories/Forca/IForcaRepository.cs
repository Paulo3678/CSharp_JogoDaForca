using JogoDaForca.ViewModel.Forca;

namespace JogoDaForca.Repositories.Forca;

public interface IForcaRepository
{
    public Task<Models.Forca> CreateAsync(CreateForcaVM vm);
    public Task<Models.Forca> GetByIdAsync(int id);
    public Task<Models.Forca> GetByIdWithDiscoveryCharsAsync(int id);
    public Task<List<Models.Forca>> GetAllAsync();
    public Task DeleteAsync();
    public Task UpdateAsync(UpdateForcaVM vm, Models.Forca forca);
    public Task AddDiscoveryCharAsync(char charactere, Models.Forca forca);
}
