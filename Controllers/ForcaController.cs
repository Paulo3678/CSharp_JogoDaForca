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
}
