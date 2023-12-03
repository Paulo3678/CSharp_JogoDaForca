namespace JogoDaForca.Models;

public class Forca
{
    public int Id { get; set; }
    public string SecretWord { get; set; }
    public int Attempts { get; set; }
    public bool Done { get; set; }
    public List<DiscoveryChar> DicoveryChars { get; set; }

    public bool CharacterExist(char character)
    {
        return true;
    }
}
