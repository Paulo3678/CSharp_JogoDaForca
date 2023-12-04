

using JogoDaForca.Data;
using JogoDaForca.Exceptions;
using JogoDaForca.ViewModel.Forca;
using Microsoft.EntityFrameworkCore;

namespace JogoDaForca.Repositories.Forca;

public class ForcaRepository : IForcaRepository
{

    private readonly AppDbContext _context;
    public ForcaRepository(AppDbContext context) => _context = context;

    public async Task<Models.Forca> CreateAsync(CreateForcaVM vm)
    {
        try
        {
            var forca = new Models.Forca
            {
                SecretWord = vm.SecretWord.ToLower(),
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

    public async Task<Models.Forca> GetByIdAsync(int id)
    {
        try
        {
            var forca = await _context.Forcas.FirstOrDefaultAsync(x => x.Id == id);
            if (forca == null)
            {
                throw new NotFoundException("Erro ao tentar buscar forca");
            }
            return forca;
        }
        catch (NotFoundException)
        {
            throw;
        }
        catch (Exception)
        {
            throw new Exception("Erro ao tentar encontrar forca");
        }
    }

    public async Task<Models.Forca> GetByIdWithDiscoveryCharsAsync(int id)
    {
        try
        {
            var forca = await _context.Forcas
                .Include(x => x.DicoveryChars)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (forca == null)
            {
                throw new NotFoundException("Erro ao tentar buscar forca");
            }
            return forca;
        }
        catch (NotFoundException)
        {
            throw;
        }
        catch (Exception)
        {
            throw new Exception("Erro ao tentar encontrar forca");
        }
    }
    public async Task UpdateAsync(UpdateForcaVM vm, Models.Forca forca)
    {
        try
        {
            Console.WriteLine("Chegou aqui");
            forca.Attempts = vm.Attempts;
            forca.Done = vm.Done;

            _context.Forcas.Update(forca);
            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw new Exception("Erro ao tentar atualizar forca"); ;
        }
    }

    public async Task AddDiscoveryCharAsync(char charactere, Models.Forca forca)
    {
        try
        {
            forca.DicoveryChars.Add(new Models.DiscoveryChar
            {
                Forca = forca,
                ForcaId = forca.Id,
                Character = charactere
            });

            await _context.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw new Exception("Erro ao tentar adicionar caracter");
        }
    }
}
