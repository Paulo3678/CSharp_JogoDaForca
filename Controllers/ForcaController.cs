using JogoDaForca.Exceptions;
using JogoDaForca.Models;
using JogoDaForca.Repositories.Forca;
using JogoDaForca.ViewModel;
using JogoDaForca.ViewModel.Forca;
using Microsoft.AspNetCore.Mvc;

namespace JogoDaForca.Controllers;

[ApiController]
[Route("v1/forcas")]
public class ForcaController : ControllerBase
{
    private readonly IForcaRepository _repository;
    public ForcaController(IForcaRepository repository) => _repository = repository;

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateForcaVM vm)
    {
        try
        {
            var forca = await _repository.CreateAsync(vm);
            return Ok(new ResponseVM<Forca>(forca));
        }
        catch (Exception)
        {
            return StatusCode(500, new ResponseVM<string>("Erro ao tentar criar forca"));
        }
    }

    [HttpPost("discovery-char")]
    public async Task<IActionResult> TryToDiscoveryChar([FromBody] TryDiscoveryCharVM vm)
    {
        try
        {
            var forca = await _repository.GetByIdWithDiscoveryCharsAsync(vm.ForcaId);
            var done = forca.Done;
            if (forca.CharacterExist(vm.Character))
            {
                await _repository.AddDiscoveryCharAsync(vm.Character, forca);
                var updateVm = new UpdateForcaVM
                {
                    Done = forca.Done,
                    Attempts = forca.Attempts
                };

                await _repository.UpdateAsync(updateVm, forca);
                return Ok(new ResponseVM<Forca>(forca));
            }
            return NotFound(new ResponseVM<string>("Caracter não encontrado"));
        }
        catch (CharacterAlreadyExistException)
        {
            return Conflict(new ResponseVM<string>("Caracter já foi encontrado"));
        }
        catch (NotFoundException)
        {
            return NotFound(new ResponseVM<string>("Forca não encontrada"));
        }
        catch (Exception)
        {
            return StatusCode(500, new ResponseVM<string>("Erro ao tentar verificar caracter"));
        }
    }
}