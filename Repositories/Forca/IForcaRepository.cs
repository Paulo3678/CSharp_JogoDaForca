using JogoDaForca.ViewModel.Forca;

namespace JogoDaForca.Repositories.Forca;

public interface IForcaRepository
{
    public Task<Models.Forca> CreateAsync(CreateForcaVM vm);
    public Task<Models.Forca> GetByIdAsync();
    public Task<List<Models.Forca>> GetAllAsync();
    public Task DeleteAsync();
    public Task UpdateAsync();
    public Task AddDiscoveryCharAsync();

}
