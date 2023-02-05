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
        int n = Cards.Count;
        while (n > 1)
        {
            n--;
            int rnd = random.Next(0,51);
            //this assignment is equivalent to 
            // Card c = Cards[rnd];
            // Cards[rnd] = Cards[n];
            // Cards[n] = c;
            (Cards[rnd], Cards[n]) = (Cards[n], Cards[rnd]);
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
                    ScoringValue = Helpers.StandardDeckService.ConvertIntToStandardValue(i),
                    Value = i
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