using System.Collections.ObjectModel;
using CardGame.Models.Enums;

namespace CardGame.Models.Models;

public class Deck
{
    public Deck()
    {
        Cards = new List<Card>();
    }
    public Deck(bool standard)
    {
        if(standard)
            CreateStandardDeck();
    }
    public Deck(List<Card> cards)
    {
        Cards = cards;
    }
    public List<Card> Cards { get; private set; }

    public void Shuffle()
    {
        Random random = new Random();
        for (int i = 0; i < 1000; i++)
        {
            int idx1 = random.Next(Cards.Count);
            int idx2 = random.Next(Cards.Count);
            if (idx1 == idx2) continue;
            (Cards[idx1], Cards[idx2]) = (Cards[idx2], Cards[idx1]);
        }
    }
    public int CardsRemaining()
    {
        return Cards.Count;
    }
    
    //TODO look into speed of remove at, perhaps there is a way to do this using bit shifts?
    public Card DealCard()
    {
        Card c = Cards[0];
        Cards.RemoveAt(0);
        return c;
    }
    
    /// <summary>
    /// 
    /// </summary>
    public void CreateStandardDeck()
    {
        Cards = new List<Card>();
        foreach (Suit suit in (Suit[])Enum.GetValues(typeof(Suit)))
        {
            for (int i = 1; i <= 13; i++)
            {
                Cards.Add(new Card()
                {
                    Rank = Helpers.StandardDeckService.ConvertIntToStandardRankString(i), 
                    Suit = suit, 
                    Value = Helpers.StandardDeckService.ConvertIntToStandardValue(i)
                });
            }
        }
    }

    public override string ToString()
    {
        string rString = string.Empty;
        foreach (Card c in Cards)
        {
            rString += c.ToString() + Environment.NewLine;
        }
        return rString;
    }
}