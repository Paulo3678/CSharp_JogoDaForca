

using JogoDaForca.Data;
using JogoDaForca.ViewModel.Forca;

namespace JogoDaForca.Repositories.Forca;

public class ForcaRepository : IForcaRepository
{

    private readonly AppDbContext _context;
    public ForcaRepository(AppDbContext context) => _context = context;


    public Task AddDiscoveryCharAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Models.Forca> CreateAsync(CreateForcaVM vm)
    {
        try
        {
            var forca = new Models.Forca
            {
                SecretWord = vm.SecretWord,
                Attempts = 0,
                Done = false,
            };
            await _context.Forcas.AddAsync(forca);
            await _context.SaveChangesAsync();

            return forca;
        }
        catch (Exception)
        {
            throw new Exception("Erro ao tentar criar forca");
        }
    }

    public Task DeleteAsync()
    {
        throw new NotImplementedException();
    }

    public Task<List<Models.Forca>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Models.Forca> GetByIdAsync()
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync()
    {
        throw new NotImplementedException();
    }
}
