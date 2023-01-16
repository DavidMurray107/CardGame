using CardGame.Models.Enums;

namespace CardGame.Models.Models;

public class Card
{
    public string? Rank { get; set; }
    public Suit Suit { get; set; }
    public int Value { get; set; }
    public override string ToString()
    {
        return $"{Rank} of {Suit.ToString()}";
    }
}