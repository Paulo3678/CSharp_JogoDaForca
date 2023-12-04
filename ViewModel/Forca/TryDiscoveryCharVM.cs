using System.ComponentModel.DataAnnotations;

namespace JogoDaForca.ViewModel.Forca;

public class TryDiscoveryCharVM
{
    [Required(ErrorMessage = "É preciso informar o id da forca para continuar")]
    public int ForcaId { get; set; }
    [Required(ErrorMessage = "É preciso informar um caractere para continuar")]
    public char Character { get; set; }
}
