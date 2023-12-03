using System.ComponentModel.DataAnnotations;

namespace JogoDaForca.ViewModel.Forca;

public class CreateForcaVM
{
    [Required(ErrorMessage = "É preciso informar a palavra secreta para continuar")]
    public string SecretWord { get; set; }
}
