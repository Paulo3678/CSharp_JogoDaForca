namespace JogoDaForca.Models;

public class DiscoveryChar
{
    public int Id { get; set; }
    public int ForcaId { get; set; }
    public Forca Forca { get; set; }
    public char Character { get; set; }
}
