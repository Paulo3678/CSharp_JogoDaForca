namespace JogoDaForca.Exceptions;

public class CharacterAlreadyExistException : Exception
{
    public CharacterAlreadyExistException(string? message) : base(message)
    {
    }
}
