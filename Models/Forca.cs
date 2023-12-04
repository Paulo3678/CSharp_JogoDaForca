using JogoDaForca.Exceptions;

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
        var charExist = DicoveryChars.Where(x => x.Character == character).FirstOrDefault();
        if (charExist != null) throw new CharacterAlreadyExistException("Caracter já encontrado");

        if (SecretWord.Contains(character))
        {
            foreach (char c in SecretWord)
            {
                if (c == character)
                {
                    Attempts++;
                }
            }
            if (SecretWord.Length == DicoveryChars.Count)
                Done = true;
            return true;
        }
        return false;
    }
}
